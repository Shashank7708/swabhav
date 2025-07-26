import { Component } from '@angular/core';
import { Registration } from "./registration/registration";

@Component({
  selector: 'app-user',
  imports: [Registration],
  templateUrl: './user.html',
  styleUrl: './user.css'
})
export class User {

}
