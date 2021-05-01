import { ElementSchemaRegistry } from '@angular/compiler';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';
import { TenentUser } from '../Tenent-User';
import { User } from '../User';
//import jwt_decode from 'jwt-decode';
import { HttpErrorResponse } from '@angular/common/http';
import jwtDecode from 'jwt-decode';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private service:TenentService,private route:Router,private _toastr:ToastrService) { }
  
user:TenentUser=new TenentUser();
login:any
tenent:Tenent=new Tenent();
disableButton=true;
companyname:string="";
UsertoCheck:User=new User();
invalidUser:string="";
show_userlist="true";
not_showUserlist="false";
FindCompanyOfUser(companyName:string){
  console.log(companyName);
  //dummy value is assign to token
  sessionStorage.setItem('token',this.show_userlist);
  return this.service.getAParticularTenent(companyName).subscribe
  ( 
    res=>{this.tenent=res,console.log(this.tenent.id),
           this._toastr.success('company name is valid'), 
          console.log("in res");
            if(this.tenent.name!=null)
            { console.log("inside disable")
              this.disableButton=false;
            } 
         },
        err=>{
          console.log(err);
          this._toastr.error('not found');
          if(err instanceof HttpErrorResponse){
            if(err.status==401){
              
              this.route.navigateByUrl("");
            }
          }
        
        }
  
    
  );
}


  ngOnInit(): void {
    this.login=new FormGroup({
      companyname:new FormControl({value:this.companyname},[Validators.required]),
      UserName:new FormControl({value:this.user.password},[Validators.required,Validators.email]),
      Password:new FormControl({value:this.user.name},[Validators.required]),
    })
  }

  onSubmit(){
    this.service.getUser(this.tenent.id,this.user.username,this.user.password).subscribe
    (res=>{console.log(res);console.log('hello');
        this._toastr.success('logging successfull');
        sessionStorage.setItem('token',res.token);
        sessionStorage.setItem('loggedin',"true");
        console.log(sessionStorage.getItem('token'));
        var payload=jwtDecode<User>(res.token);
        this.UsertoCheck.id=payload.id;
        this.UsertoCheck.userName=payload.userName;
        this.UsertoCheck.password=payload.password;
        this.UsertoCheck.role=payload.role;
      if(this.UsertoCheck.role=="Admin"){
       // sessionStorage.setItem('user-info');
        console.log('admin');
        
        localStorage.setItem('show-list',this.show_userlist);
        localStorage.setItem('tenent',JSON.stringify(this.tenent));
        
      
       this.route.navigateByUrl("/tenent/user-list")
      }
      else if(this.UsertoCheck.role=='normal'){
        console.log('normal');
       
        localStorage.setItem('user',JSON.stringify(this.UsertoCheck));
        localStorage.setItem('tenent',JSON.stringify(this.tenent));
  
        localStorage.setItem("show-list",this.not_showUserlist);
        this.route.navigateByUrl("/tenent/user/show-contact");
      }
      else if(this.UsertoCheck.role="superadmin"){
        console.log('superadmin');

        this.route.navigateByUrl('secure/getalltenent');
      }
    },
    err=>{
      console.log(err);
      if(err instanceof HttpErrorResponse){
        if(err.status==401){
          this._toastr.error('invalid username or password');
          this.route.navigateByUrl("");
        }
      }
    
    }
    )
  }
}
