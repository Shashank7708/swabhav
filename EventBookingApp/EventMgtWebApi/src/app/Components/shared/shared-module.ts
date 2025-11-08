import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Users } from '../users/users';
import { CreateUser } from '../create-user/create-user';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginMaster } from '../login-master/login-master';
import { AppRoutingModule } from "../../app-routing-module";



@NgModule({
  declarations: [
    Users,
    CreateUser,
    LoginMaster
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule
],
  exports:[
    Users
  ]
})
export class SharedModule { }
