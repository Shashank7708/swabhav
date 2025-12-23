import { Component } from '@angular/core';
import { dateTimestampProvider } from 'rxjs/internal/scheduler/dateTimestampProvider';

@Component({
  selector: 'app-data-bindin',
  imports: [],
  templateUrl: './data-bindin.html',
  styleUrl: './data-bindin.css',
})
export class DataBindin {
coursename:string="Angular20";
isActive:boolean=false;
currentDate: Date=new Date();
rollno:number=10;
minLen:number=5;

constructor(){
  console.log(this.coursename);
}
}
