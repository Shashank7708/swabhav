import { HttpClient } from '@angular/common/http';
import { getInterpolationArgsLength } from '@angular/compiler/src/render3/view/util';
import { Injectable } from '@angular/core';
import { observable, Observable } from 'rxjs';
import { Address } from './AddressDepartment/address';
import{Contact} from './ContactDepartment/contact'
import { Tenent } from './LoginAndRegister/tenent';
import { User } from './LoginAndRegister/User';
@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  constructor(private http:HttpClient) { }


  tenentId:string="EC1221D0-8197-4BE3-44F6-08D903D176E5";
  userId:string="6593C768-7093-4994-45AB-08D903D1A4F3";
  _getContactUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contacts";

getContact():Observable<Contact[]>{
return this.http.get<Contact[]>(this._getContactUrl);
}

getaddressUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{"
 //getaddress(tenentid:any,userid:any,contactid:any):Observable<Address[]>{
   
   //return this.http.get<Address[]>(this.getaddressUrl+userid+"}/address")
 //}

_postContactUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/register"

addcontact(tenentid:any,userid:any,val:Contact){
  
return this.http.post(this._postContactUrl,val);
}

_deleteContactUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{";

deletecontact(val:any){
 return this.http.delete(this._deleteContactUrl+val+"}/delete");
}

_updateurl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{"

editContact(id:any,val:any){
  return this.http.put(this._updateurl+id+"}/update",val);
}


 postaddressUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{"
 AddAddress(id:any,val:Address){
   return this.http.post(this.postaddressUrl+id+"}/address/register",val);
 }


 editaddressUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{";
editaddress(cid:any,aid:any,val:any){
  return this.http.put(this.editaddressUrl+cid+"}/address/{"+aid+"}/edit",val);
}

deleteaddressUrl:string="http://localhost:57364/api/v1/tenents/{"+this.tenentId+"}/users/{"+this.userId+"}/contact/{";
deleteaddress(cid:any,aid:any){
  return this.http.delete(this.deleteaddressUrl+cid+"}/address/{"+aid+"}/delete");
}









}

