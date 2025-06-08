import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './pager/pager.component';



@NgModule({
  declarations: [
    PagerComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ReactiveFormsModule,
    CommonModule,
    PagerComponent
  ]
})
export class SharedModule { }
