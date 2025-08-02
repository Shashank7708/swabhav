import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { Form, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Productservice } from '../../services/productservice';
import { Product } from '../../Model/product';

@Component({
  selector: 'app-item-master',
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './item-master.html',
  styleUrl: './item-master.css'
})
export class ItemMaster implements OnInit{
@ViewChild('myModal') modal:ElementRef | undefined
productForm:FormGroup=new FormGroup({})
productList:Product[]=[];
productService=inject(Productservice)


constructor(private fb:FormBuilder){

}
ngOnInit(): void {
  this.SetFormState();
  this.getproduct();
}

  SetFormState(){
    this.productForm=this.fb.group({
      id: [0],
      Name:['',[Validators.required]],
      Description:['',[Validators.required]],
      Price:[0,[Validators.required]],
      IsActive:[true,[Validators.required]],

    })
  }
  OpenModal(){
    this.SetFormState();
    debugger;
    let prodModel=document.getElementById('myModal');
    if(prodModel!=null){
      prodModel.style.display="block";
    }
  }

  closeModel(){
    if(this.modal!=null)
      this.modal.nativeElement.style.display="none";
  }
  OnSubmit(){
    console.log(this.productForm.value);
  }

  getproduct(){
    this.productService.getallproduct().subscribe((res)=>{
      debugger;
      this.productList=res;
    }
    )
  }
}
