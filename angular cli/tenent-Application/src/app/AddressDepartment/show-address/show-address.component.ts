import { state } from '@angular/animations';
import { ConvertActionBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ContactServiceService } from 'src/app/contact-service.service';
import { Contact } from 'src/app/ContactDepartment/contact';
import { Tenent } from 'src/app/LoginAndRegister/tenent';
import { User } from 'src/app/LoginAndRegister/User';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Address } from '../address';

@Component({
  selector: 'show-address',
  templateUrl: './show-address.component.html',
  styleUrls: ['./show-address.component.scss']
})
export class ShowAddressComponent implements OnInit {
  public addresses:Address[]=[];
  tenent:Tenent=new Tenent();
  user:User=new User();
  contact:Contact=new Contact();
  constructor(private service:TenentService,private route:Router,private _router:ActivatedRoute) { }
 
  getdata(){
    this.service.getaddress(this.tenent.id,this.user.id,this.contact.id).subscribe(data=>{ 
      console.log(data);
      this.addresses=data});
  }
  contactid:any;
  ngOnInit(): void {
    this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}")
    this.user=JSON.parse(localStorage.getItem('user')||"{}")
    this.contact=JSON.parse(localStorage.getItem('contact')||"{}")
    this.getdata();
  }
  editClick(address:Address){
    localStorage.setItem('address',JSON.stringify(address));
    this.route.navigateByUrl("tenent/user/contact/edit-address");
  }
  deleteClick(addressid:any){
   this.service.deleteaddress(this.tenent.id,this.user.id,this.contact.id,addressid).subscribe(
     res=>{console.log(res)},err=>console.log(err)
   )
  }
  addClick(){
    this.route.navigateByUrl("tenent/user/contact/add-address");
  }

  backtocontactlist(){
    this.route.navigateByUrl("tenent/user/show-contact");
  }

}
