import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BusyService } from '../services/busy.service';
import { delay, finalize } from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {

  const busyService = inject(BusyService)
  busyService.busy()

  return next(req).pipe(
    delay(600),
    finalize(() =>
      busyService.idle()
    )
  )
};