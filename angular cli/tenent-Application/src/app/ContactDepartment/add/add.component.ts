import { Component, OnInit,Input,Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { disableDebugTools } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ContactServiceService } from 'src/app/contact-service.service';
import { Tenent } from 'src/app/LoginAndRegister/tenent';
import { User } from 'src/app/LoginAndRegister/User';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Contact } from '../contact';

@Component({
  selector: 'add-contact',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  
  constructor(private service:TenentService,private _router:Router) { }
  
contact:Contact=new Contact();
addcontact:any;
tenent:Tenent=new Tenent();
user:User=new User();
ngOnInit(): void { 
  this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}");
  this.user=JSON.parse(localStorage.getItem('user')||"{}");
  
  this.addcontact=new FormGroup({
  Id:new FormControl({value:this.contact.id,disabled:true}),
  Name:new FormControl({value:this.contact.name},[Validators.required]),
  Mobileno:new FormControl({value:this.contact.mobileno},[Validators.required,Validators.minLength(10),Validators.maxLength(10)]),

  })
}
public onSubmit(){
  
  this.service.addcontact(this.tenent.id,this.user.id,this.contact).subscribe(data=>console.log(data));
  this._router.navigateByUrl("tenent/user/show-contact");
 }

}
