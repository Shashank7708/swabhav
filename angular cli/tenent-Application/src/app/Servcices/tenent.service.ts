import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { Injectable,Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, ObservableLike } from 'rxjs';
import { Address } from '../AddressDepartment/address';
import { Contact } from '../ContactDepartment/contact';
import { Tenent } from '../LoginAndRegister/tenent';
import { TenentUser } from '../LoginAndRegister/Tenent-User';
import { User } from '../LoginAndRegister/User';

@Injectable({
  providedIn: 'root'
})
export class TenentService {

  constructor(private http:HttpClient,private route:Router) { }

_url="http://localhost:57364/api/v1/tenents/";

loggedIn(){
  return  !!sessionStorage.getItem('loggedin');
}

logout(){
  //localStorage.removeItem('token');
  localStorage.removeItem('user');
  sessionStorage.removeItem('token');
  sessionStorage.removeItem('loggedin');
  localStorage.removeItem('tenent');
  localStorage.removeItem('contact'),
  localStorage.removeItem('address'),
  localStorage.removeItem('show-list')
  this.route.navigateByUrl('');
}

addTenent(tenent:TenentUser){
  return this.http.post(this._url+"register",
  {
    "name":tenent.name,
    "tenentstrength":tenent.strength,
  },{responseType:'text'});
}

getAParticularTenent(tenentName:any):Observable<any>{
  return this.http.get<any>(this._url+""+tenentName+"/getIdBasedOnname", { headers: { 'token': '' }});
}



getUser(tenentid:any,username:any,password:any):Observable<any>{
  return this.http.get<any>(this._url+""+tenentid+"/user/"+username+"/"+password,{ headers: { 'token': '' }});
}
addUser(tenentid:any,user:TenentUser,role:any){

  return this.http.post(this._url+"{"+tenentid+"}/user/register",
  {
    "username":user.username,
    "password":user.password,
    "role":role
  },{responseType:'text'})
}

getUserOftenent(tenentid:any):Observable<User[]>{
  return this.http.get<User[]>(this._url+tenentid+"/user");
}

deleteUser(tenentid:any,userid:any){
 return this.http.delete(this._url+tenentid+"/user/"+userid+"/delete")
}

updateuser(tenentid:any,userid:any,user:User){
 return this.http.put(this._url+tenentid+"/user/"+userid+"/update",user,{responseType:'text'});
}

getContactOfUser(tenentid:any,userid:any):Observable<Contact[]>{
  return this.http.get<Contact[]>(this._url+tenentid+"/users/"+userid+"/contacts");
}


addcontact(tenentid:any,userid:any,contact:Contact){
  return this.http.post(this._url+tenentid+"/users/"+userid+"/contact/register",contact);
}


editcontact(tenentid:any,userid:any,contact:Contact){
  return this.http.put(this._url+tenentid+"/user/"+userid+"/contact/"+contact.id+"/update",contact);
}

deletecontact(tenentid:any,userid:any,contactid:any){
  return this.http.delete(this._url+tenentid+"/users/"+userid+"/contact/"+contactid+"/delete");
}

getaddress(tenentid:any,userid:any,contactid:any):Observable<Address[]>{
  return this.http.get<Address[]>(this._url+tenentid+"/users/"+userid+"/contact/"+contactid+"/address")
}

addaddress(tenentid:any,userid:any,contactid:any,address:Address){
  return this.http.post(this._url+tenentid+"/users/"+userid+"/contact/"+contactid+"/address/register",address)
}

editaddress(tenentid:any,userid:any,contactid:any,address:Address){
  return this.http.put(this._url+tenentid+"/users/"+userid+"/contact/"+contactid+"/address/"+address.id+"/edit",address)
}

deleteaddress(tenentid:any,userid:any,contactid:any,addressid:any){
  return this.http.delete(this._url+tenentid+"/users/"+userid+"/contact/"+contactid+"/address/"+addressid+"/delete");
}

getalltenent():Observable<Tenent[]>{
return this.http.get<Tenent[]>(this._url);
}

deleteTenen(tenentid:any){
 return this.http.delete(this._url+tenentid+"/delete");
}

updateTenent(tenentid:any,tenent:Tenent){
 return this.http.put(this._url+tenentid+"/update",tenent);
}

}
