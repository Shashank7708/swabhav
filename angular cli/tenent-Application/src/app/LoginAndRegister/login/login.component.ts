import { ElementSchemaRegistry } from '@angular/compiler';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';
import { TenentUser } from '../Tenent-User';
import { User } from '../User';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private service:TenentService,private route:Router) { }
  
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
  return this.service.getAParticularTenent(companyName).subscribe
  (
    res=>{this.tenent=res,console.log(this.tenent.id),console.log("in res");
            if(this.tenent.name!=null)
            { console.log("inside disable")
              this.disableButton=false;
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
    (res=>{console.log(res);this.UsertoCheck=res;
      if(this.UsertoCheck.role=="Admin"){
        localStorage.setItem('tenent',JSON.stringify(this.tenent));
        localStorage.setItem('token',this.UsertoCheck.userName);
        localStorage.setItem('show-list',this.show_userlist);
       this.route.navigateByUrl("/tenent/user-list")
      }
      else if(this.UsertoCheck.role=='normal'){
        localStorage.setItem('user',JSON.stringify(this.UsertoCheck));
        localStorage.setItem('tenent',JSON.stringify(this.tenent));
        localStorage.setItem('token',this.UsertoCheck.userName);
        localStorage.setItem("show-list",this.not_showUserlist);
        this.route.navigateByUrl("/tenent/user/show-contact");
      }
      else if(this.UsertoCheck.role="superadmin"){
        localStorage.setItem('token',this.UsertoCheck.userName);
        this.route.navigateByUrl('secure/getalltenent');
      }
    });
  }
}
