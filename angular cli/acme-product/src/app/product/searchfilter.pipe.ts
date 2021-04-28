import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchfilter'
})
export class SearchfilterPipe implements PipeTransform {
  transform(products:any[],searchValue:string): any {
    console.log(products);
    console.log(searchValue);
    if(!products || !searchValue){
      return products;
    }
    return products.filter(products=>
      products.productName.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()))
  }
  
}
