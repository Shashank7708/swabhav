import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../Shared/user-service';
import { Logins } from '../users';

@Component({
  selector: 'app-login-master',
  standalone: false,
  templateUrl: './login-master.html',
  styleUrl: './login-master.css'
})
export class LoginMaster implements OnInit,OnDestroy{
logins:Logins[]=[];

constructor(private _router:Router,private _userService:UserService){}

ngOnInit(): void {
  this.GetAllLogins();
}

GetAllLogins(){
  this._userService.GetLoginsAsync().subscribe({
    next:(data)=>{
      this.logins=data;
    },
    error:(err)=>{
      console.log(err);
    }
  })
}

ngOnDestroy(): void {
  
}
Editlogin(id:number){}

Deletelogin(id:number){}
}
