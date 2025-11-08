import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-lifecycle-event',
  standalone: false,
  templateUrl: './lifecycle-event.html',
  styleUrl: './lifecycle-event.css',
})
export class LifecycleEvent implements OnInit,AfterViewInit,OnDestroy {

  courseName:string="Angular Tutorial";
rollno:number=123;
mintestLength=4;
spanClassName='secondary';
city='';
  constructor(){
    
    console.log("constructor  loaded");
    setTimeout(() => {
      this.rollno=777;
    }, 10000);
    console.log('hello world')
  }
  ngOnInit(): void {
     console.log('ngOnInit');
  }
  ngAfterViewInit(): void {
    console.log("ngAfterViewInit");
  }
  ngOnDestroy(): void {
    console.log('ngOnDestroy');
  }
OnCityChange(){
  alert("city changes");
  console.log("city changes");
 console.log(this.city);
}
}
