import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './pager/pager.component';
import { CustomInputComponent } from './custom-input/custom-input.component';



@NgModule({
  declarations: [
    PagerComponent,
    CustomInputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ReactiveFormsModule,
    CommonModule,
    PagerComponent,
    CustomInputComponent
  ]
})
export class SharedModule { }
