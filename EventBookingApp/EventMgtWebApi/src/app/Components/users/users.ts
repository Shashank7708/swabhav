import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Shared/user-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users',
  standalone: false,
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class Users implements OnInit {
  users: any[] = [];
  constructor(private userService: UserService,private _route:Router) { }
  
  ngOnInit(): void {
   this.getalluser();
  }
  getalluser() {
    debugger;
    this.userService.getUsers().subscribe({
      next: (data) => {
        debugger;
        this.users = data;
        console.log(this.users);
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        console.log('complete')
      }
    })
  }

  EditUser(id:number){
    localStorage.setItem("EditUserId",id.toString());
    this.NavigatetoCreateUser();
  }
DeleteUser(id:number){
 this.userService.DeleteUser(id).subscribe({
  next:(data)=>{
    console.log(data);
    alert("User Deleted Successfully");
    this.getalluser();
  },
  error:(err)=>{alert(err)}
})
}
  NavigatetoCreateUser(){
    this._route.navigate(['Create-user']);
  }
}
