import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode=false;



  registerTogol(){
    if(this.registerMode){
      this.registerMode=false;
    }
    else{
      this.registerMode=true;
    }

  }
}
