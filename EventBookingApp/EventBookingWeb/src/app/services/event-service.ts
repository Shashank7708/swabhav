import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfirmBookingRequest, EventBooking, EventsObj } from '../model/user.model';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private readonly _baseUrl:string="https://localhost:7051/api";
  constructor(private _http:HttpClient){}

  addEvents(obj:any):Observable<any>{
    return this._http.post<any>(`${this._baseUrl}/Event`,obj);
  }
  getAllEvents():Observable<EventsObj[]>{
    return this._http.get<EventsObj[]>(`${this._baseUrl}/Event/GetEvents`);
  }

editEvent(obj:any):Observable<any>{
    return this._http.put<any>(`${this._baseUrl}/Event`,obj);
  }

  getEventBookingBasedOnUserId(id:number):Observable<EventBooking[]>{
    debugger;
    return this._http.get<EventBooking[]>(`${this._baseUrl}/Booking/GetBookingUserId/${id}`);
  }

  AddEventBookings(objList:ConfirmBookingRequest[]){
    return this._http.post<any>(`${this._baseUrl}/Booking/ConfirmBooking`,objList);
  }

}
