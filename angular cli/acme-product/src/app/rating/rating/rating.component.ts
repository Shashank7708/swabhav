import { Component, Input, OnInit, Output,EventEmitter } from '@angular/core';


@Component({
  selector: 'rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {

  @Input() rating !:number;
  @Output() ratingEvent = new EventEmitter<number>();
   constructor() { 
     
     this.ratingEvent.emit(this.rating);
   }
 
   ngOnInit(): void {
   }
 
}
