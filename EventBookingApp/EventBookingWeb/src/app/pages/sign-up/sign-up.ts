import { Component } from '@angular/core';
import { userRegister } from '../../model/user.model';
import { User } from '../../services/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  standalone: false,
  templateUrl: './sign-up.html',
  styleUrl: './sign-up.css',
})
export class SignUp {
  IsRequired:boolean=true;
  userRegisterObj: userRegister = new userRegister();

  constructor(private _userService:User, private _route:Router){  }


  registerUser(){
    debugger;
    this._userService.registerUser(this.userRegisterObj).subscribe({
      next:(data:userRegister)=>{
        debugger;
        alert(data);
        this._route.navigate(['/login']);
      },
      error: (err)=>{
        alert('Something went wrong '+err)
      }
    })
  }
}
