import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EditComponent } from './ContactDepartment/edit/edit.component';
import { AddComponent } from './ContactDepartment/add/add.component';
import { ShowComponent } from './ContactDepartment/show/show.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { NotFoundComponentComponent } from './NotFound/not-found-component/not-found-component.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ShowAddressComponent } from './AddressDepartment/show-address/show-address.component';
import { EditAddressComponent } from './AddressDepartment/edit-address/edit-address.component';
import { AddAddressComponent } from './AddressDepartment/add-address/add-address.component';

import { TenentRegisterComponent } from './LoginAndRegister/tenent-register/tenent-register.component';
import { UseRegisterComponent } from './LoginAndRegister/use-register/use-register.component';
import{TenentService} from './Servcices/tenent.service';
import { LoginComponent } from './LoginAndRegister/login/login.component';
import { UserListComponent } from './LoginAndRegister/user-list/user-list.component';
import { UserEditComponent } from './LoginAndRegister/user-edit/user-edit.component';
import { SuperadminComponent } from './LoginAndRegister/superadmin/superadmin.component';
import { EditTenentComponent } from './LoginAndRegister/edit-tenent/edit-tenent.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthGuard } from './auth.guard';
import {TokenInterceptorService} from './token-interceptor.service';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
import { ShowfavouriteComponent } from './LoginAndRegister/showfavourite/showfavourite.component';
@NgModule({
  declarations: [
    AppComponent,
    EditComponent,

    AddComponent,
    ShowComponent,
    NotFoundComponentComponent,
    ShowAddressComponent,
    EditAddressComponent,
    AddAddressComponent,
    TenentRegisterComponent,
    UseRegisterComponent,
    LoginComponent,
    UserListComponent,
    UserEditComponent,
    SuperadminComponent,
    EditTenentComponent,
    NavbarComponent,
    ShowfavouriteComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut:2000,
      positionClass:'toast-top-right',
      preventDuplicates:false,
    })
  ],
  providers: [TenentService,AuthGuard,
    {
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptorService,
    multi:true
  }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
