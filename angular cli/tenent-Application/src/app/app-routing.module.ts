import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {AddComponent} from './ContactDepartment/add/add.component';
import{ShowComponent} from "./ContactDepartment/show/show.component";
import {EditComponent} from './ContactDepartment/edit/edit.component';
import {ShowAddressComponent} from './AddressDepartment/show-address/show-address.component';
import {EditAddressComponent} from './AddressDepartment/edit-address/edit-address.component';
import {AddAddressComponent} from './AddressDepartment/add-address/add-address.component';
import{UseRegisterComponent} from "./LoginAndRegister/use-register/use-register.component"
import {TenentRegisterComponent} from './LoginAndRegister/tenent-register/tenent-register.component';
import { LoginComponent } from './LoginAndRegister/login/login.component';
import { UserListComponent } from './LoginAndRegister/user-list/user-list.component';
import {UserEditComponent} from './LoginAndRegister/user-edit/user-edit.component';
import {AppComponent} from './app.component';
import {SuperadminComponent} from './LoginAndRegister/superadmin/superadmin.component';
import {EditTenentComponent} from "./LoginAndRegister/edit-tenent/edit-tenent.component";
import { AuthGuard } from './auth.guard';


 const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {path:'secure/getalltenent',component:SuperadminComponent,canActivate:[AuthGuard]},
  {path:'secure/tenent/register',component:TenentRegisterComponent,canActivate:[AuthGuard]},
  {path:'secure/tenent/edit',component:EditTenentComponent,canActivate:[AuthGuard]},
  {path:'home',component:LoginComponent},
  {path:"tenent/user-list",component:UserListComponent},
  {path:"tenent/user/show-contact",component:ShowComponent,canActivate:[AuthGuard]},
  {path:"tenent/user-register",component:UseRegisterComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/edit",component:UserEditComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/contact/edit",component:EditComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/add-contact",component:AddComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/contatc/address",component:ShowAddressComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/contact/add-address",component:AddAddressComponent,canActivate:[AuthGuard]},
  {path:"tenent/user/contact/edit-address",component:EditAddressComponent,canActivate:[AuthGuard]},
  
 // {path:"**",component:NotFoundComponentComponent}
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
