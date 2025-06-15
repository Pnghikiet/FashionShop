import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ControlValueAccessor, FormControl } from '@angular/forms';

@Component({
  selector: 'app-custom-input',
  templateUrl: './custom-input.component.html',
  styleUrl: './custom-input.component.css'
})
export class CustomInputComponent implements ControlValueAccessor{
  @Input() placeholder:string = ''
  @Input() control!: FormControl
  @Input() type: string = 'text'
  @Input() label: string = ''
  @Output() focus = new EventEmitter()
  value = ''
  isDisabled = false

  onChange = (_: any) => {};
  onTouched = () => {};

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  onFocus()
  {
    this.focus.emit()
  }
}
