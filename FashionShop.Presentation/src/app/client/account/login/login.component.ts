import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  errorMessage:string |null =  null

  loginForm = new FormGroup({
    email: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required)
  })

  constructor(private accountService: AccountService, private route: Router){}

  onLogin()
  {
    this.accountService.Login(this.loginForm.value).subscribe({
      next: response => {
        this.route.navigateByUrl('/products')
      },
      error: err => {
        this.errorMessage = 'Tài Khoản Hoặc Mật Khẩu Không Đúng.'
      }
    })
  }

  onFocus()
  {
    this.errorMessage = null
  }
}
