import { Component } from '@angular/core';
import { UserLogin } from '../../model/user.model';
import { User } from '../../services/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
isLoginMode: boolean = true;
loginObj:UserLogin=new UserLogin();
isRequired=true;

constructor(private _userService:User, private _route:Router){}
 toggleMode() {
    this.isLoginMode = !this.isLoginMode;
  }
loginUser(){
  debugger;
  this._userService.loginUser(this.loginObj).subscribe({
    next:(data)=>{
      debugger;
      alert(data);
     localStorage.setItem('loginObj',JSON.stringify(data));
     localStorage.setItem('token',data.token);
     localStorage.setItem('username',data.username);
     localStorage.setItem('role',data.role);
      const abc=localStorage.getItem('loginObj');
      console.log(data);
      this._route.navigate(['/events']);
    },
    error:(err)=>{
      alert("Something went wrong");
    }
  })
}

}
