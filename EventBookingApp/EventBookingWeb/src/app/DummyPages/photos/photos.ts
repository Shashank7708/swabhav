import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { count } from 'rxjs';

@Component({
  selector: 'app-photos',
  standalone: false,
  templateUrl: './photos.html',
  styleUrl: './photos.css',
})
export class Photos implements OnInit {

  photosList:any[]=[];
  newPhoto:any={
  "albumId":0,
  "id":0,
  "title":"accusm beateu",
  "url":"",
  "thumbnailUrl":""
  }
  http=inject(HttpClient)
  constructor(){}

  ngOnInit(): void {
    this.getAllPhotos();
  }

  getAllPhotos(){
    this.http.get<any[]>("https://jsonplaceholder.typicode.com/photos").subscribe({
      next: (data)=>{
        debugger;
        var counter=0;
        for(let i in data){
          this.photosList.push(data[i]);
          if(counter==10)
              break;
          counter++;
        }
         // this.photosList=data;
      },
      error:(err)=>{
        alert(err);
      }
    })
  }

  resetForm(){
    this.newPhoto.title="",
    this.newPhoto.url="",
    this.newPhoto.thumbnailUrl=""
  }
  submit(){
    console.log(this.newPhoto);
  }
}
