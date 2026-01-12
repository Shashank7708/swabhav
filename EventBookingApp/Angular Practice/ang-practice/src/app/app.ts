import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Admin } from "./Shared/admin/admin";
import { User } from "./Shared/user/user";
import { DataBindin } from "./Shared/data-bindin/data-bindin";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Admin, User, DataBindin],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ang-practice');
}
