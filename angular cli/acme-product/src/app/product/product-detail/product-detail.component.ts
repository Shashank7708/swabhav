import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  constructor(private route:Router) { }
product:any;
  ngOnInit(): void {
    this.product=JSON.parse(localStorage.getItem('product')|| "{}");
  }

  ratingHandler(event:any){
    
  }
  back(){
    this.route.navigateByUrl("productlist");
  }
}
