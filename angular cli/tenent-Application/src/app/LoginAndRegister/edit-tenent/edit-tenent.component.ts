import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';

@Component({
  selector: 'app-edit-tenent',
  templateUrl: './edit-tenent.component.html',
  styleUrls: ['./edit-tenent.component.scss']
})
export class EditTenentComponent implements OnInit {

  constructor(private service:TenentService,private route:Router) { }
tenent:Tenent=new Tenent();
edittenent:any;
  ngOnInit(): void {
    this.tenent=JSON.parse(localStorage.getItem('edittenent')||"{}");
    console.log("hellowdfvf: "+this.tenent.tenentStrength)
this.edittenent=new FormGroup({
  Name:new FormControl({value:this.tenent.name},[Validators.required]),
  Strength:new FormControl({value:this.tenent.tenentStrength},[Validators.required]),
  
}
  )
  }

  onSubmit(){
    console.log("hello "+this.tenent.name+" streingth: "+this.tenent.tenentStrength);
    this.service.updateTenent(this.tenent.id,this.tenent).subscribe(
      res=>{console.log(res);
        this.route.navigateByUrl('/secure/getalltenent')},
      err=>{
        console.log(err);
        if(err instanceof HttpErrorResponse){
          if(err.status==401){
            console.log("inside 401 not autorize")
            this.service.logout();
            this.route.navigateByUrl("");
          }
        }
      
      },
    )
  
  }

}
