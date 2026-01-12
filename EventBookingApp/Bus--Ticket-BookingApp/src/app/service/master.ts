import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class MasterService {
  
 readonly _baseUrl: string="https://projectapi.gerasim.in/api/BusBooking/";
  constructor(private _http:HttpClient){}

  getLocations():Observable<any[]>{
    return this._http.get<any[]>(this._baseUrl+"GetBusLocations");
  }

  searchBus(from:number,to:number,travelDate:string):Observable<any[]>{
    return this._http.get<any[]>(`${this._baseUrl}searchBus?fromLocation=${from}&toLocation=${to}&travelDate=${travelDate}`)
  }

}
