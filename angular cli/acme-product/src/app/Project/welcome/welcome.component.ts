import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/product.service';



@Component({
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  constructor(private service:ProductService) { }
products:any;
  ngOnInit(): void {
this.service.getproduct().subscribe(
  res=>{console.log(res),this.products=res}
);

  }
  image:string="./assets/logo.jpg";

}
