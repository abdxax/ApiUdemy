import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
  constructor(private account:AccountService,private route:Router,private toaster:ToastrService){}
  ngOnInit():void{
    //this.getCurrentUser();
    this.currentUser$=this.account.curerntUser$;
  }


  login(){
    console.log(this.model);
    this.account.login(this.model).subscribe({
      next:()=>{
        this.route.navigateByUrl('/members')

      },
      error:error=>this.toaster.error(error.error)
    })
  }

  logout(){
    this.account.logout();
    this.route.navigateByUrl('/')

  }

}
