import { HttpClient } from '@angular/common/http';
import { inject,Injectable } from '@angular/core';
import { Product } from '../Model/product';

@Injectable({
  providedIn: 'root'
})
export class Productservice {
  private apiURL:string="https://localhost:6004/";
  http=inject(HttpClient);

  constructor(){
  }

  getallproduct(){
    debugger;
    return this.http.get<Product[]>(this.apiURL+"api/product");
  }
}