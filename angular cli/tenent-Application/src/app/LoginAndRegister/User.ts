export class User{
    id:string="";
    userName:string="";
    password:string="";
    role:string=""
}


/*
<div class="form-group">
                        <label class="font-weight-bold">Company-Name</label>
                        <input type="text" #name (keyup.enter)="FindCompanyOfUser(name.value)"
                         [(ngModel)]="companyname"
                         class="form-control"
                         formControlName="companyname"
                         placeholder="Enter Username(Email)">
                         </div>
                            
                    <div class="form-group">
                        <label class="font-weight-bold">UserName</label>
                        <input type="email"
                         [(ngModel)]="tenent.username"
                         class="form-control"
                         formControlName="UserName"
                         placeholder="Enter Username(Email)">
                            <div class="text-danger" *ngIf="adduser.controls['UserName'].hasError('required') 
                                    && adduser.controls['UserName'].touched" >
                                    Username Field Cannot be Empty 
                            </div >
                            <div class="text-danger" *ngIf="adduser.controls['UserName'].hasError('email') 
                                      && adduser.controls['UserName'].touched">
                                    Please Enter a Valid Email
                            </div>
                            
                    </div>

                    <div class="form-group">
                        <label class="font-weight-bold">Password</label>
                        <input type="password"
                         [(ngModel)]="user.password"
                         class="form-control"
                         formControlName="Password">
                            <div class="text-danger" *ngIf="adduser.controls['Password'].hasError('required') 
                                    && adduser.controls['Password'].touched" >
                                    Password Field Cannot be Empty 
                            </div>
                    </div>
                */