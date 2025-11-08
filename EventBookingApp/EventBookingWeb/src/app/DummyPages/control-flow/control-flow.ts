import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-control-flow',
  standalone: false,
  templateUrl: './control-flow.html',
  styleUrl: './control-flow.css',
})
export class ControlFlow {

  selectVal:string="";
  otherVal:string='';
  
  cityList:any[]=["Dublin","Cork","Donegal"];

  studentData=[
    {name:'AAA',Age:10},
    {name:'BBB',Age:11},
    {name:'CCC',Age:14},
    {name:'RRR',Age:78},
  ]
  
  IsActive=signal(true);
  changeStatus(val:boolean){
    this.IsActive.set(val);
  }
}
