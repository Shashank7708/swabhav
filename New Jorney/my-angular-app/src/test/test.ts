import { Component } from '@angular/core';

@Component({
  selector: 'app-test',
  imports: [],
  templateUrl: './test.html',
  styleUrl: './test.css'
})
export class Test {
  public name="Vishwas";
  public successClass="text-success";
 greeting : string="";

  greetUser(){
    return "Hello"+this.name;
  }
  onClick(){
 greeting="abv";
    console.log( 'Welcome to code evolution' );
  }
}
