import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  standalone: false,
  templateUrl: './booking.html',
  styleUrl: './booking.css',
})
export class Booking implements OnInit{

  BookingForm:FormGroup;
  constructor(private _route:Router, private _fb:FormBuilder){
    this.BookingForm=this._fb.group({
      id:[0],
      username:[0,Validators.required],
      eventId:[0,Validators.required],
      status:["",Validators.required]
    })
  }

  ngOnInit(): void {
    
  }
}
