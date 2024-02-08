import { Component } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  model:any={};
  //loggedIn=false;
  currentUser$:Observable<User | null>=of(null);
  constructor(private account:AccountService){}
  ngOnInit():void{
    //this.getCurrentUser();
    this.currentUser$=this.account.curerntUser$;
  }


  login(){
    console.log(this.model);
    this.account.login(this.model).subscribe({
      next:resp=>{
        console.log(resp);

      },
      error:error=>console.log(error)
    })
  }

  logout(){
    this.account.logout();

  }

}
