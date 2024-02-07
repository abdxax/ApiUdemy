import { Component } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  model:any={};
  loggedIn=false;
  constructor(private account:AccountService){}
  ngOnInit():void{
    this.getCurrentUser();
  }

  getCurrentUser(){
    this.account.curerntUser$.subscribe({
      next:user=>this.loggedIn=!!user,
      error:error=>console.log('error')
    })
  }

  login(){
    console.log(this.model);
    this.account.login(this.model).subscribe({
      next:resp=>{
        console.log(resp);
        this.loggedIn=true;
      },
      error:error=>console.log(error)
    })
  }

  logout(){
    this.account.logout();
    this.loggedIn=false;
  }

}
