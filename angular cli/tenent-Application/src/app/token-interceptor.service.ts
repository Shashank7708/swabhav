import { JsonPipe } from '@angular/common';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './LoginAndRegister/User';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {
token:any;
tokenreq:any;
  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('intoken interceptor');
    this.token=sessionStorage.getItem('token');
    if(sessionStorage.getItem('token')!=null){
      this.tokenreq=req.clone({
        setHeaders: {
          'token':this.token,
        }
      })
      
    }
    return next.handle(this.tokenreq);
  }
  

}
