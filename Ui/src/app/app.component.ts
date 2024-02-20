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
  constructor(private account:AccountService){

  }
  ngOnInit(): void {

  this.setCrrentUser();
  }



  setCrrentUser(){
    const userString=localStorage.getItem('user');
    if(!userString) return;
    const user:User=JSON.parse(userString);
    this.account.setCurrentUser(user);
  }




}
