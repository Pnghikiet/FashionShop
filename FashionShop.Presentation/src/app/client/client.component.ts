import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { GuardService } from '../services/guard.service';
import { GuardClientService } from './guard/guard-client.service';
import { CartService } from './cart/cart.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent implements OnInit{

  constructor(private accountService : AccountService, private guardClientService: GuardClientService,
    private cartService: CartService
  ){}

  ngOnInit(): void {
    this.LoadCurrentUser()
    this.LoadCurrentCart()
  }

  LoadCurrentUser()
  {
    const token = this.guardClientService.GetToken()
    if(token) this.accountService.LoadCurrentUser().subscribe()
  }

  LoadCurrentCart()
  {
    const userId = this.guardClientService.GetUserId()
    if(userId) this.cartService.GetCurrentCart(userId).subscribe(cart => {
        if(cart !== null)
        {
          // localStorage.setItem('cartId',cart.id)
          this.cartService.SetCart(cart)
        }
      })
  }
}
