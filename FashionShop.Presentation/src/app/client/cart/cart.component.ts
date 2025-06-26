import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { GuardClientService } from '../guard/guard-client.service';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{

  isLoaded: boolean = false
  
  constructor(public cartService: CartService, public guardClientService: GuardClientService){}
  
  totalCost$: Observable<number> = this.cartService.currentCart$.pipe(
    map(data => data?.items.reduce((sum,item) => sum + (item.price*item.quantity),0) ?? 0)
  )

  ngOnInit(): void {
  }

  OnIncrease(productId: number)
  {
    const userId = this.guardClientService.GetUserId()

    this.cartService.UpdateitemInCart(productId,undefined,userId).subscribe(response =>{
      this.cartService.GetCurrentCart(userId).subscribe(cart =>{
        if(cart !== null)
          this.cartService.SetCart(cart)
      })
    })
  }

  OnDecrease(productId: number)
  {
    const userId = this.guardClientService.GetUserId()

    this.cartService.UpdateitemInCart(productId,-1,userId).subscribe(response =>{
      this.cartService.GetCurrentCart(userId).subscribe(cart =>{
        if(cart !== null)
          this.cartService.SetCart(cart)
      })
    })
  }

  OnRemoveItem(productId:number)
  {
    const userId = this.guardClientService.GetUserId()

    this.cartService.RemoveItemFromCart(productId,userId).subscribe(() =>{
      this.cartService.GetCurrentCart(userId).subscribe(cart => {
        if(cart !== null)
          this.cartService.SetCart(cart)
      })
    })
  }
}
