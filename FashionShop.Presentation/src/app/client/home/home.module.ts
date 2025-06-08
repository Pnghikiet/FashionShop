import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { NgImageSliderModule } from 'ng-image-slider';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    NgImageSliderModule
  ]
})
export class HomeModule { }
