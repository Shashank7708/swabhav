import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TenentService } from 'src/app/Servcices/tenent.service';
import { Tenent } from '../tenent';
import { User } from '../User';

@Component({
  selector: 'app-showfavourite',
  templateUrl: './showfavourite.component.html',
  styleUrls: ['./showfavourite.component.scss']
})
export class ShowfavouriteComponent implements OnInit {

  constructor(private service:TenentService,private route:Router,private _toastr:ToastrService) { }
  users:User[]=[];
tenent:Tenent=new Tenent();
  
ngOnInit(): void {
    this.tenent=JSON.parse(localStorage.getItem('tenent')||"{}");
    this.service.getfavourite(this.tenent.id).subscribe(
      res=>{this.users=res;
        console.log(res);

      },
      err=>{
        this._toastr.success('removed successfully');
      console.log(err);
      console.log("inside error");
      if(err instanceof HttpErrorResponse){
        if(err.status==401){
          console.log("inside 401 not autorize")
          this.service.logout();
          this.route.navigateByUrl("");
        }
      }
      }
    )
  }

  RemoveFavourite(userid:any){
    this.service.removefavourite(this.tenent.id,userid).subscribe(
      res=>{
        console.log(res),
        this._toastr.success("removed from favourite")
      },
      err=>{
        this._toastr.error('error 401')
        console.log(err);
        if(err instanceof HttpErrorResponse){
          if(err.status==401){
            console.log("inside 401 not autorize")
            this.service.logout();
            this.route.navigateByUrl("");
          }
        }
  
      }

    )
  }

  back(){
    this.route.navigateByUrl('tenent/user-list');
  }

}
