import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EventService } from '../../services/event-service';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { NotifierService } from "angular-notifier";
import { ConfirmBookingRequest, EventBooking, EventsObj } from '../../model/user.model';
@Component({
  selector: 'app-events',
  standalone: false,
  templateUrl: './events.html',
  styleUrl: './events.css',
})
export class Events implements OnInit {
  EventForm: FormGroup;
  EditMode: boolean = false;
  eventList: EventsObj[] = [];
  eventBooking: EventBooking[] = [];
  IdToEdit: number = 0;
  IsAdmin: boolean = false;
  bookingList: any[] = [];
confirmBookingRequestList:ConfirmBookingRequest[]=[];
  constructor(private _route: Router, private _fb: FormBuilder, private _eventService: EventService, private _notifierService:NotifierService) {
    //this.initiateForm();
    const loginObj = JSON.parse(localStorage.getItem('loginObj')!);
    const role = loginObj.role;
    this.IsAdmin = (role != null && role != undefined && role == "Admin") ? true : false;
    this.EventForm = this._fb.group({
      id: [0],
      title: ["", Validators.required],
      description: ["", Validators.required],
      startDate: ["", Validators.required],
      endDate: ["", Validators.required],
      venueName: ["", Validators.required],
      capacity: ["", Validators.required],
      imageUrl: [""],
      price: ["", Validators.required],
      isActive: [true, Validators.required]
    });
  }


  ngOnInit(): void {
    this.getAllEvents();
  }
  getAllEvents() {
    debugger;
    this._eventService.getAllEvents().subscribe({
      next: (data)   => {
        debugger;
        this.eventList = data.map(x => ({
  id: x.id,
  title: x.title,
  
  startDate: x.startDate,
  endDate: x.endDate,
  capacity: x.capacity,
  isActive: x.isActive,
  price: x.price,
  venueName: x.venueName,
  description: x.description,
  imageUrl: x.imageUrl,
  IsBooked: false,
  createdBy: x.createdBy,
  createdOn: x.createdOn
}));
        this.getEventBookingForUserId();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  CancelTicket(id: string) {
    debugger;
    var item = this.eventList.find(x => x.id == id);
    this.eventList = this.eventList.filter(x => x.id != item?.id);
    item!.IsBooked = false;
    this.eventList.push(item!);
  }
  BookTicket(id: string) {
    debugger;
    var item = this.eventList.find(x => x.id == id);
    this.eventList = this.eventList.filter(x => x.id != item?.id);
    item!.IsBooked = true;
    this.eventList.push(item!);
  }

ConfirmBooking(){
  debugger;
  var loginObj=JSON.parse(localStorage.getItem('loginObj')!);
  var username=loginObj.username;
  var userId=loginObj.userId;
  var items=this.eventList.filter(x=>x.IsBooked==true);
  for(let i=0;i<items.length;i++){
    var obj=items[i];
    var confirmBookingRequest=new ConfirmBookingRequest();
    confirmBookingRequest.EventId=obj.id;
    confirmBookingRequest.Status="Pending";
    confirmBookingRequest.CreatedOn=new Date();
    confirmBookingRequest.UserId=userId;
    confirmBookingRequest.UserName=username;
    this.confirmBookingRequestList.push(confirmBookingRequest);
  }
  debugger;
  this._eventService.AddEventBookings(this.confirmBookingRequestList).subscribe({
    next:(data)=>{
      debugger;
      console.log(data);
      this._notifierService.notify('success',data);
      window.location.reload();
    },
    error:(err)=>{
      console.log(err);
    }
  })

}

  getEventBookingForUserId() {
    debugger;
    const tempLoginObj = localStorage.getItem("loginObj");
    var loginObj = JSON.parse(tempLoginObj!);
    const userid = loginObj.userId;
    this._eventService.getEventBookingBasedOnUserId(userid).subscribe({
      next: (data) => {
        debugger;
        this.eventBooking = data;
        for (let i in this.eventList) {
          for (let j in this.eventBooking) {
            if (this.eventList[i].id == this.eventBooking[j].eventId) {
              this.eventList[i].IsBooked = true;
            }
          }
        }
      },
      error: (err) => {
        console.log(err);
      }
    })
  }


  EditEventForm(obj: any) {
    debugger;
    this.EditMode = true;
    this.IdToEdit = obj.id;
    this.EventForm.get("id")?.setValue(obj.id);
    this.EventForm.get("title")?.setValue(obj.title);
    this.EventForm.get("description")?.setValue(obj.description);
    this.EventForm.get("startDate")?.setValue(obj.startDate);
    this.EventForm.get("endDate")?.setValue(obj.endDate);
    this.EventForm.get("venueName")?.setValue(obj.venueName);
    this.EventForm.get("capacity")?.setValue(obj.capacity);
    this.EventForm.get("imageUrl")?.setValue(obj.imageUrl);
    this.EventForm.get("price")?.setValue(obj.price);
    this.EventForm.get("isActive")?.setValue(obj.isActive);
  }

  //}
  AddEditEvent() {
    debugger;
    const tempLoginObj = localStorage.getItem('loginObj')!;
    const loginObj = JSON.parse(tempLoginObj);
    var createdby = loginObj.username;
    if (!this.EditMode) {
      let val = this.EventForm.get("isActive")?.value;
      var obj = {
        "title": this.EventForm.get("title")?.value,
        "description": this.EventForm.get("description")?.value,
        "startDate": this.EventForm.get("startDate")?.value,
        "endDate": this.EventForm.get("endDate")?.value,
        "venueName": this.EventForm.get("venueName")?.value,
        "capacity": this.EventForm.get("capacity")?.value,
        "imageUrl": this.EventForm.get("imageUrl")?.value,
        "isActive": this.EventForm.get("isActive")?.value,
        "price": this.EventForm.get("price")?.value,
        "createdBy": (createdby == null || createdby == undefined) ? "Admin" : createdby,
        "createdOn": new Date()

      }
      debugger;
      this._eventService.addEvents(obj).subscribe({
        next: (data) => {
          debugger;
          console.log(data)
        },
        error: (err) => {
          console.log(err)
        }
      });
    }
    else {
      const createdby = localStorage.getItem('loginObj.username');
      let val = this.EventForm.get("isActive")?.value;
      var editobj = {
        "id": this.IdToEdit,
        "title": this.EventForm.get("title")?.value,
        "description": this.EventForm.get("description")?.value,
        "startDate": this.EventForm.get("startDate")?.value,
        "endDate": this.EventForm.get("endDate")?.value,
        "venueName": this.EventForm.get("venueName")?.value,
        "capacity": this.EventForm.get("capacity")?.value,
        "imageUrl": this.EventForm.get("imageUrl")?.value,
        "isActive": this.EventForm.get("isActive")?.value,
        "price": this.EventForm.get("price")?.value,
        "createdBy": (createdby == null || createdby == undefined) ? "Admin" : createdby,
      }
      debugger;
      this._eventService.editEvent(editobj).subscribe({
        next: (data) => {
          debugger;

          this.IdToEdit = 0;
          this.EditMode = false;
          console.log(data);
          this.EventForm.reset({ "isActive": true });
        },
        error: (err) => {
          console.log(err)
        }
      });
    }

  }
  ResetForm() {
    //this.EventForm.reset({isActive:true});
    this.EventForm.reset();
  }
}
