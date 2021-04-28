import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';
import { TenentUser } from '../Tenent-User';
import { User } from '../User';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {
  tenentafteraddclick:Tenent=new Tenent();
  
  constructor(private service:TenentService,private route:Router,private router:ActivatedRoute) { }
user:User=new User();
adduser:any;
tenent:Tenent=new Tenent();

disableButton=true;
companyname:string="";
role="normal";
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

  ngOnInit(){
    this.tenentafteraddclick=JSON.parse(localStorage.getItem('tenent')|| '{}')
    this.user=JSON.parse(localStorage.getItem('user-edit')|| "{}")
    this.companyname=this.tenentafteraddclick.name;
    console.log(this.tenentafteraddclick);
    console.log('hello');
    this.adduser=new FormGroup({
      companyname:new FormControl({value:this.companyname},[Validators.required]),
      UserName:new FormControl({value:this.user.userName},[Validators.required,Validators.email]),
      Password:new FormControl({value:this.user.password},[Validators.required]),
    })
  }

  onSubmit(){
    this.service.updateuser(this.tenent.id,this.user.id,this.user).subscribe
    (res=>{console.log(res);
            this.backtoList();
    },err=>console.log(err));

  }
  backtoList(){
    this.route.navigateByUrl("/tenent/user-list");
  }

 }


