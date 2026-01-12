import { Component, OnInit } from '@angular/core';
import { Dummyclass } from '../class/dummyclass'
@Component({
  selector: 'app-template-form',
  standalone: false,
  templateUrl: './template-form.html',
  styleUrl: './template-form.css'
})
export class TemplateForm implements OnInit{
  dummycls: Dummyclass=new Dummyclass();
  
  topics=['Angular','React','Vue']
  constructor(){}
  ngOnInit(): void {
    this.dummycls.name="Romy";
    this.dummycls.email="shetye";
    this.dummycls.phoneno="989069504";
    this.dummycls.preferenceTime="Morning"
    this.dummycls.topic="Angular";
  }
}
