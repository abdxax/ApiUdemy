import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Dating app';
  users:any;
  constructor(private http:HttpClient,private account:AccountService){

  }
  ngOnInit(): void {
  this.getUsers();
  this.setCrrentUser();
  }

  getUsers(){
    this.http.get('https://localhost:7154/api/User/getUser').subscribe({
      next:response=>this.users=response,
      error:error=>console.log(error),
      complete:()=>{console.log("Request Complate ")}
    });
  }

  setCrrentUser(){
    const userString=localStorage.getItem('user');
    if(!userString) return;
    const user:User=JSON.parse(userString);
    this.account.setCurrentUser(user);
  }




}
