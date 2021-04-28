import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductlistComponent } from './productlist/productlist.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductService } from '../product.service';
import { RatingModule } from '../rating/rating.module';
import {FormsModule} from '@angular/forms';
import { SearchfilterPipe } from './searchfilter.pipe';

@NgModule({
  declarations: [
    ProductlistComponent,
    ProductDetailComponent,
    SearchfilterPipe,
    
  ],
  imports: [
    CommonModule,
    RatingModule,
    FormsModule,
  
  ],
  exports:[
    ProductDetailComponent,
    ProductlistComponent
  ],
})
export class ProductModule { }
