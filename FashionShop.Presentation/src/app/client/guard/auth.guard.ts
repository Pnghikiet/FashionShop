import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { GuardClientService } from './guard-client.service';
import { AccountService } from '../account/account.service';

export const authGuard: CanActivateFn = (route, state) => {

  const guardClientService = inject(GuardClientService)
  const router = inject(Router)
  const accountService = inject(AccountService)

  const token = guardClientService.GetToken()

  if(!token)
  {
    return router.parseUrl('/account/login')
  }

  const isExp = guardClientService.IsTokenExpired()

  if(isExp)
  {
    accountService.Logout()
    return router.parseUrl('/account/login')
  }
  

  return token? true: false;
};
