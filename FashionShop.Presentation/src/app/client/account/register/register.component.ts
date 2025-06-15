import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, ValidationErrors, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  errorMessage:string |null =  null
  registerForm = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.email]),
    password: new FormControl('',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/gm)]),
    confirmPassword: new FormControl('',Validators.required),
    displayName: new FormControl('',Validators.required)
  },{
    validators: this.matchPassword('password','confirmPassword')
  })

  constructor(private accountService: AccountService, private route: Router){}

  matchPassword(password: string, confirmPassword: string) : ValidatorFn
  {
    return (formGroup : AbstractControl): ValidationErrors | null =>{
      const passwordControl= formGroup.get(password)
      const confirmPasswordControl = formGroup.get(confirmPassword)

      if(!passwordControl || !confirmPasswordControl)
        return null

      if(confirmPasswordControl.errors && !confirmPasswordControl.errors['noMatch'])
        return null

      const err = passwordControl.value === confirmPasswordControl.value ? null :{
        nomatch: true
      }

      confirmPasswordControl.setErrors(err)
      return err
    }
  }

  onRegister()
  {
    this.accountService.Register(this.registerForm.value).subscribe({
      next: response => {
        this.route.navigateByUrl('/products')
      },
      error: err =>{
        console.log(err.error?.['message'])
        this.errorMessage = err.error?.['message']
      }
    })
  }

  onFocus()
  {
    this.errorMessage = null
  }
}
