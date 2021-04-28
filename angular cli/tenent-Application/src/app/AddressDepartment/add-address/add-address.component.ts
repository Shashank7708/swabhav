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
  selector: 'add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.scss']
})
export class AddAddressComponent implements OnInit {

  constructor(private service:TenentService,private _router:ActivatedRoute,private route:Router) { }
contactid:any;
address:Address=new Address();
addAddress:any;
tenent:Tenent=new Tenent();
user:User=new User();
contact:Contact=new Contact();
ngOnInit(): void {
  
  this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}")
  this.user=JSON.parse(localStorage.getItem('user')||"{}")
  this.contact=JSON.parse(localStorage.getItem('contact')||"{}")
 
    this.addAddress=new FormGroup({
        Id:new FormControl({value:this.address.id,disabled:true}),
        City:new FormControl({value:this.address.city},[Validators.required]),
        State:new FormControl({value:this.address.state},[Validators.required]),
        Country:new FormControl({value:this.address.country},[Validators.required]),
        })
}

onSubmit(){
  this.service.addaddress(this.tenent.id,this.user.id,this.contact.id,this.address).subscribe(data=>console.log(data));
  this.BackToList();
}

BackToList(){    
  this.route.navigateByUrl("/tenent/user/contatc/address");
}

}
