import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  users:any;

constructor(private http:HttpClient){}
  ngOnInit(): void {
    this.getUsers();
  }

  registerTogol(){
    if(this.registerMode){
      this.registerMode=false;
    }
    else{
      this.registerMode=true;
    }

  }

  getUsers(){
    this.http.get('https://localhost:7154/api/User/getUser').subscribe({
      next:response=>this.users=response,
      error:error=>console.log(error),
      complete:()=>{console.log("Request Complate ")}
    });
  }

  cansleRrg(event:boolean){
  this.registerMode=event;
  }
}
