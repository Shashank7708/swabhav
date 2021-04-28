import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/product.service';
import {FormsModule} from '@angular/forms'
@Component({
  selector: 'productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {

  constructor(private service:ProductService,private route:Router) { }
products:any[]=[];
  ngOnInit(): void {
    this.service.getproduct().subscribe(
      res=>{console.log(res),this.products=res},err=>console.log(err),
    )
    
  }
  searchValue:any;
  disabled=false;
  showimage(){
    this.disabled=!this.disabled;
  }  
  ratingHandler(event:any){
    
  }


showproductdetails(product:any){
  localStorage.setItem('product',JSON.stringify(product));
  this.route.navigateByUrl('/productdetail');

  }
}
