import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validator, Validators } from '@angular/forms';
import { UserService } from '../../Shared/user-service';
import { Users } from '../users';
import { Router } from '@angular/router';
@Component({
  selector: 'app-create-user',
  standalone: false,
  templateUrl: './create-user.html',
  styleUrl: './create-user.css'
})
export class CreateUser implements OnInit, OnDestroy {
userform!:FormGroup;
IsEdit:boolean=false;
IdToEdit:any=0;
userObj:Users=new Users();
IsActiveChecked:boolean=false;
constructor(private fb:FormBuilder,private _userService: UserService, private _route: Router){}
ngOnInit(): void {
  this.userform=this.fb.group({
    id:[''],//[Validators.required, Validators.pattern('^[0-9]+$')]
    name:['',Validators.compose([Validators.required,Validators.maxLength(100)])],
    isActive:[false],
    CreatedOn:[''],
    CreatedBy:[''],
  })
  debugger;
  if (localStorage.getItem("EditUserId") != null && localStorage.getItem("EditUserId") != undefined) {
      this.IsEdit=true;
      this.IdToEdit=localStorage.getItem("EditUserId");
      this.fillFormValues();
  }
}

ngOnDestroy(): void {
  debugger;
  if(localStorage.getItem("EditUserId")!= null && localStorage.getItem("EditUserId") != undefined ) {
    localStorage.removeItem("EditUserId");
  }

}

fillFormValues(){
  this._userService.getUsersOnId(this.IdToEdit).subscribe({
    next:(data)=>{
      debugger;
      this.userform.get('name')?.setValue(data.name);
      this.userform.get('isActive')?.setValue(data.isActive);
      this.userform.get('id')?.setValue(data.id)
      this.userform.get('CreatedBy')?.setValue(data.createdBy);
      this.userform.get('CreatedOn')?.setValue(data.createdOn)
    }
  })
  
}


OnSubmit(){
  debugger;
console.log(this.userform.get('name')?.value);
console.log(this.userform.get('isActive')?.value);
if(this.IsEdit){
  this.userObj.id=parseInt(this.IdToEdit);
  this.userObj.Name=this.userform.get('name')?.value;
  this.userObj.IsActive=this.userform.get('isActive')?.value;
  this.userObj.CreatedBy=this.userform.get('CreatedBy')?.value;
  this.userObj.CreatedOn=this.userform.get('CreatedOn')?.value;
  console.log(this.userObj.CreatedOn,this.userform.get('CreatedOn')?.value);
  this._userService.UpdateUser(this.userObj).subscribe({
  next:(data)=>{
    console.log(data);
    alert("User updated Successfully");
    this._route.navigate(['']);
  },
  error:(err)=>{alert(err)}
})
}
else{
  this.userObj.Name=this.userform.get('name')?.value;
  this.userObj.IsActive=this.userform.get('isActive')?.value;
  this.userObj.CreatedBy="Admin";
  this.userObj.CreatedOn=new Date().toISOString();
  this._userService.addUser(this.userObj).subscribe({
  next:(data)=>{
    console.log(data);
    alert("User Added Successfully");
    this._route.navigate(['']);
  },
  error:(err)=>{alert(err)}
})
}
//const obj={
//  Name:this.userform.get('name')?.value,
//  IsActive:this.userform.get('isActive')?.value,
//  CreatedBy:'Admin',
//  CreatedOn:new Date().toISOString()
//}
}

CancelAddUpdate(){
  this._route.navigate(['']);
}

}
