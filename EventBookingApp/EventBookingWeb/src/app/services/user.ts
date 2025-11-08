import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin, userRegister } from '../model/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class User {
  private readonly _baseUrl:string="https://localhost:7051/api/";
  constructor(private http:HttpClient){}

  registerUser(obj:userRegister):Observable<userRegister>{
    return this.http.post<userRegister>(this._baseUrl+"Auth/RegisterUserAsync",obj);
  }
  loginUser(obj:UserLogin):Observable<any>{
    return this.http.post<any>(this._baseUrl+"Auth/login",obj);
  }
}
