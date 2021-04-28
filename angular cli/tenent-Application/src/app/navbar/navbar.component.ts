import { Component, OnInit } from '@angular/core';
import { Tenent } from '../LoginAndRegister/tenent';
import {TenentService} from '../Servcices/tenent.service'
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public service:TenentService) { }
tenent:Tenent=new Tenent();

  ngOnInit(): void {
    if(this.service.loggedIn()){
      this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}");
    }
  }


}
