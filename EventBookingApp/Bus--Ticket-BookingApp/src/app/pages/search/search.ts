import { Component, inject, OnInit } from '@angular/core';
import { MasterService } from '../../service/master';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { bus } from '../../models/bus';
import { dateTimestampProvider } from 'rxjs/internal/scheduler/dateTimestampProvider';
import { DatePipe } from '@angular/common';
import { RouterLink, RouterModule } from "@angular/router";
@Component({
  selector: 'app-search',
  imports: [FormsModule, RouterModule],
  providers:[DatePipe],
  templateUrl: './search.html',
  styleUrl: './search.css',
})
export class Search implements OnInit {

  locations: any[] = [];
  busList:bus[]=[];
  _masterService = inject(MasterService);
  searchObj: any ={
    fromLocation:"",
    toLocation:"",
    travelDate:""
  }
  

    constructor( private _datePipe:DatePipe){
      const b1:bus={
        busName:"Jivdani Travels",
        vendorName:"Jv1",
        Duration:9,
        rating:4.5,
        price:993,
        departureTime:new Date,
        arrivalTime:new Date,
        fromLocationId:1,
        toLocationId:2
      };
      const b2:bus={
        busName:"Jivdani Travels",
        vendorName:"Jv1",
        Duration:9,
        rating:4.5,
        price:449,
        departureTime:new Date,
        arrivalTime:new Date,
        fromLocationId:2,
        toLocationId:1
      };
      this.busList.push(b1);
      this.busList.push(b2);
    }
  ngOnInit(): void {
    this.getAllLocations();
  }
  getAllLocations() {
    debugger;
    this._masterService.getLocations().subscribe({
      next: (data) => {
        debugger;
        this.locations = data;
      },
      error: (err) => {
        console.log("GetAllLocations");
      }
    })
  }


searchBus(){
  debugger;
  //const {fromlocation:number,toLocation:number,travelDate:Date}=this.searchObj;   //another way to access :Object destructor
  if(this.searchObj.toLocation==this.searchObj.fromLocation){
    console.log("same location");
      return
  }
  this.busList=this.busList.filter(x=>x.fromLocationId.toString()==this.searchObj.fromLocation &&  x.toLocationId.toString()==this.searchObj.toLocation && this._datePipe.transform(x.departureTime, 'yyyy-MM-dd')==this.searchObj.travelDate);
  this._masterService.searchBus(this.searchObj.fromlocation,this.searchObj.toLocation,this.searchObj.travelDate).subscribe({
    next:(data)=>{
      this.busList=data;
    },
    error:(err)=>{
      console.log(err);
    }
  })
}
}
