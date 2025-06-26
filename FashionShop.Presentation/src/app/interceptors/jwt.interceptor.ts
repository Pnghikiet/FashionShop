import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError, throwError } from 'rxjs';
import { inject } from '@angular/core';
import { AccountService } from '../client/account/account.service';
import { Router } from '@angular/router';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountService = inject(AccountService)
  const router = inject(Router)

  if(req.url.startsWith(environment.apiUrl))
  {
    const token = localStorage.getItem('token')
    if(token)
    {
      req = req.clone({
        setHeaders:{
          Authorization: `Bearer ${token}`
      }})
    }
    return next(req);
  }

  return next(req).pipe(
    catchError(error => {
      if(error.status === 401)
      {
        accountService.Logout()
        router.navigate(['/account/login'])
      }
      return throwError(() => error)
    })
  )
};
