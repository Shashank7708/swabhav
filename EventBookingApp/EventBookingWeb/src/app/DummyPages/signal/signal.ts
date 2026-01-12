import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-signal',
  standalone: false,
  templateUrl: './signal.html',
  styleUrl: './signal.css',
})
export class Signal {

  abc=signal(20);
  cityList=signal(["Pune","Mumbai"]);
  studentObj:any={
    name:"Joseph",
    city:"Dublin"
  }
  signalStudentObj=signal<any>({
    name:"Romy",
    age:20
  });
  ChangeABC(){
    this.abc.set(40);
  }
  UpdateCityList(cityName:string){
    this.cityList.update(old=>[...old,cityName]);
  }


  UpdateStudentObj(name:string){
    this.studentObj.name=name;
    //signal
    this.signalStudentObj.update(obj=>({
      ...obj,name:name
    }))
  }
}
