import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  imports: [],
  templateUrl: './admin.html',
  styleUrl: './admin.css',
})
export class Admin implements OnInit, AfterViewInit, OnDestroy {
  
  constructor(){
    console.log("Admin constructor executed");
  }
  ngOnInit(): void {
    
  }
  ngAfterViewInit(): void {
     console.log('ngOnDestory')
  }
  ngOnDestroy():void{
    console.log('ngOnDestory')
  }
}
