import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseURL='https://localhost:7154/api/';
private currentluser=new BehaviorSubject<User|null>(null);
curerntUser$=this.currentluser.asObservable();
  constructor(private http:HttpClient) { }

  login(model:any){
  return this.http.post<User>(this.baseURL+'account/login',model).pipe(
    map((response:User)=>{
      const user=response;
      if(user){
        localStorage.setItem('user',JSON.stringify(user));
        this.currentluser.next(user);
      }
    })
  );
  }

  setCurrentUser(user:User){
    this.currentluser.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentluser.next(null);
  }
}
