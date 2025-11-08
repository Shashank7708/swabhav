import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Logins } from '../Components/users';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url:string="https://localhost:7109/";
  constructor(private http:HttpClient){}

  getUsers():Observable<any[]>{
    return this.http.get<any[]>(this.url+'api/User/GetUserAsync');
  }
  getUsersOnId(id:number):Observable<any>{
    return this.http.get<Observable<any>>(this.url+`api/User/GetUser/${id}`);
  }
  addUser(obj:any):Observable<any>{
    return this.http.post<any>(this.url+"api/User/AddUserAsync",obj);
  }
  UpdateUser(obj:any):Observable<any>{
    return this.http.put<any>(this.url+`api/User/UpdateUser/${obj.id}`,obj);
  }
   DeleteUser(id:number):Observable<any>{
    return this.http.get<any>(this.url+`api/User/DeleteUserAsync/${id}`);
  }

  GetLoginsAsync():Observable<Logins[]>{
    return this.http.get<Logins[]>(this.url+`api/Login/GetLoginsAsync`);
  }

 GetLoginAsync(id:number):Observable<any[]>{
    return this.http.get<any[]>(this.url+`api/Login/GetLoginAsync/${id}`);
  } 
  AddLoginAsync(obj:Logins):Observable<any[]>{
    return this.http.post<any[]>(this.url+`api/Login/AddLoginAsync`,obj);
  }
  UpdateLoginAsync(obj:Logins):Observable<any[]>{
    return this.http.put<any[]>(this.url+`api/Login/UpdateLoginAsync`,obj);
  }

}
