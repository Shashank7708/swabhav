import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ContactServiceService } from 'src/app/contact-service.service';
import { Contact } from 'src/app/ContactDepartment/contact';
import { Tenent } from 'src/app/LoginAndRegister/tenent';
import { User } from 'src/app/LoginAndRegister/User';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Address } from '../address';

@Component({
  selector: 'edit-address',
  templateUrl: './edit-address.component.html',
  styleUrls: ['./edit-address.component.scss']
})
export class EditAddressComponent implements OnInit {
  address:Address=new Address();
  editAddress:any;
  
tenent:Tenent=new Tenent();
user:User=new User();
contact:Contact=new Contact();
  constructor(private service:TenentService,private route:Router,private _router:ActivatedRoute) { }

  ngOnInit(): void {
    this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}")
  this.user=JSON.parse(localStorage.getItem('user')||"{}")
  this.contact=JSON.parse(localStorage.getItem('contact')||"{}")
   this.address=JSON.parse(localStorage.getItem('address')||"{}") 
  this.editAddress=new FormGroup({
    Id:new FormControl({value:this.address.id,disabled:true}),
    City:new FormControl({value:this.address.city},[Validators.required]),
    State:new FormControl({value:this.address.state},[Validators.required]),
    Country:new FormControl({value:this.address.country},[Validators.required]),
    })
}

onSubmit(){
  this.service.editaddress(this.tenent.id,this.user.id,this.contact.id,this.address).subscribe(
    res=>console.log(res),err=>console.log(err),
  )
  this.BackToList();
}

BackToList(){    
  this.route.navigateByUrl("tenent/user/contatc/address");
}
}
