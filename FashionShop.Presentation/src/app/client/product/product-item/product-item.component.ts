import { Component, Input } from '@angular/core';
import { Product } from '../../../shared/models/product.model';
import { GuardClientService } from '../../guard/guard-client.service';
import { CartService } from '../../cart/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent {
  @Input() productItem!:Product;

  constructor(private clientGuardService: GuardClientService, private cartService: CartService,
    private router : Router
  )
  {}

  OnAddItemToCart()
  {
    const userId = this.clientGuardService.GetUserId()

    if(!userId)
    {
      this.router.navigateByUrl('/account/login')
    }
    else
    {
      this.cartService.UpdateitemInCart(this.productItem.id,undefined,userId).subscribe(() =>{
        this.cartService.GetCurrentCart(userId).subscribe(cart =>{
          if(cart !== null)
            this.cartService.SetCart(cart)
        })
      })
      
    }
  }
}
