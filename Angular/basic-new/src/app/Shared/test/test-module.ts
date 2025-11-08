import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Test } from './test';
import { TemplateForm } from '../template-form/template-form';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    Test,
    TemplateForm
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    Test,
    TemplateForm
]
})
export class TestModule { }
