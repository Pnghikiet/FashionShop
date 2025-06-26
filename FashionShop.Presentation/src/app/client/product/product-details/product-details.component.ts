import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../../shared/models/product.model';
import { GuardClientService } from '../../guard/guard-client.service';
import { CartService } from '../../cart/cart.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit{
  product!: Product
  quantity = 1

  constructor(private productService : ProductService, private activeRoute: ActivatedRoute,
    private clientGuardService: GuardClientService, private router: Router,
    private cartService: CartService
  ){}
  
  ngOnInit(): void {
    this.getProductById()
  }
  

  getProductById()
  {
    const id = this.activeRoute.snapshot.paramMap.get('id')
    if(id)
    {
      this.productService.getProductById(+id).subscribe({
        next: data =>{
          this.product = data
        },
        error: err =>{
          console.log(err)
        }
      })
    }
  }

  OnIncrease()
  {
    if(this.quantity < 9)
      this.quantity += 1
  }

  OnDescrease()
  {
    if(this.quantity > 1)
      this.quantity -= 1
  }

  OnAddItemToCart()
  {
    const userId = this.clientGuardService.GetUserId()

    if(!userId)
    {
      this.router.navigateByUrl('/account/login')
    }
    else
    {
      this.cartService.UpdateitemInCart(this.product?.id,this.quantity,userId).subscribe(() =>{
        this.cartService.GetCurrentCart(userId).subscribe(cart =>{
          if(cart !== null)
            this.cartService.SetCart(cart)
        })
      })
      
    }
  }
}
