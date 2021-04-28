import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';

@Component({
  selector: 'app-superadmin',
  templateUrl: './superadmin.component.html',
  styleUrls: ['./superadmin.component.scss']
})
export class SuperadminComponent implements OnInit {

  constructor(private service:TenentService,private route:Router) { }
tenents:Tenent[]=[];
  ngOnInit(): void {
    this.service.getalltenent().subscribe(
      res=>{this.tenents=res,console.log(res)},err=>console.log(err),
    )
  }

  show_userlist="true";
  getusers(tenent:any){
  localStorage.setItem('tenent',JSON.stringify(tenent));
  localStorage.setItem('show-list',this.show_userlist);
 this.route.navigateByUrl("/tenent/user-list")
  }
  deleteClick(id:any){
    this.service.deleteTenen(id).subscribe(
      res=>{console.log(res)},err=>console.log(err),
    )
  }
  editClick(tenent:Tenent){
    localStorage.setItem('edittenent',JSON.stringify(tenent));
    this.route.navigateByUrl('/secure/tenent/edit');
  }

  addClick(){
    this.route.navigateByUrl("/secure/tenent/register");
  }
}
