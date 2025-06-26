import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vnCurrency'
})
export class VnCurrencyPipe implements PipeTransform {

  transform(value: number, symbol: string = 'đ'): string {
    return `${value.toLocaleString('vi-VN')} ${symbol}`;
  }

}
