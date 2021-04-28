import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';
import { TenentUser } from '../Tenent-User';

@Component({
  selector: 'user-register',
  templateUrl: './use-register.component.html',
  styleUrls: ['./use-register.component.scss']
})
export class UseRegisterComponent implements OnInit {
  tenentafteraddclick:Tenent=new Tenent();
  
  constructor(private service:TenentService,private route:Router,private router:ActivatedRoute) { }
user:TenentUser=new TenentUser();
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
    this.companyname=this.tenentafteraddclick.name;
    console.log(this.tenentafteraddclick);
    console.log('hello');
    this.adduser=new FormGroup({
      companyname:new FormControl({value:this.companyname},[Validators.required]),
      UserName:new FormControl({value:this.user.password},[Validators.required,Validators.email]),
      Password:new FormControl({value:this.user.name},[Validators.required]),
    })
  }

  onSubmit(){
    this.service.addUser(this.tenent.id,this.user,this.role).subscribe
    (res=>{console.log(res);
            this.backtoList();
    },err=>console.log(err));

  }
  backtoList(){
    this.route.navigateByUrl("/tenent/user-list");
  }


}


