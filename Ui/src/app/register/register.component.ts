import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Output() cancelRegister =new EventEmitter();
model:any={};
constructor(private account:AccountService,private toast:ToastrService){

}

register(){
  this.account.register(this.model).subscribe({
    next:responce=>{
      console.log(responce);
      this.cancel;
    },
    error:error=>{
      this.toast.error(error.error)
      console.log(error)
    }
  })
  console.log(this.model);
}

cancel(){
 this.cancelRegister.emit(false);
}
}
