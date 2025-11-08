import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateUser } from './Components/create-user/create-user';
import { Users } from './Components/users/users';
import { LoginMaster } from './Components/login-master/login-master';

const routes: Routes = [
  {path:'',component:Users},
  {path:'Create-user',component:CreateUser},
  {path:'LoginMaster',component:LoginMaster}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
