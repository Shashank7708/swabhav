import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import {TenentService} from "./Servcices/tenent.service"


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
 
  constructor(private service:TenentService,private router:Router){

  }

canActivate():boolean{
if(this.service.loggedIn()){
  return true;
}
else{
  
  this.router.navigateByUrl("/home");
  return false;
}
}

}
