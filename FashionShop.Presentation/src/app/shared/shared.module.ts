import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './pager/pager.component';
import { CustomInputComponent } from './custom-input/custom-input.component';
import { VnCurrencyPipe } from './custom-pipe/vn-currency.pipe';



@NgModule({
  declarations: [
    PagerComponent,
    CustomInputComponent,
    VnCurrencyPipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ReactiveFormsModule,
    CommonModule,
    PagerComponent,
    CustomInputComponent,
    VnCurrencyPipe
  ]
})
export class SharedModule { }
