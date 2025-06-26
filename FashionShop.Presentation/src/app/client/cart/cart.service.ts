import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { BehaviorSubject, map } from 'rxjs';
import { Cart } from '../../shared/models/cart.model';
import { GuardClientService } from '../guard/guard-client.service';
import { CartItem } from '../../shared/models/cartitem.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl = environment.apiUrl
  private currentCartSource = new BehaviorSubject<Cart |null>(null)
  currentCart$ = this.currentCartSource.asObservable()

  constructor(private http: HttpClient) { }

  GetCurrentCart(userId: string)
  {
    return this.http.get<Cart | null>(this.baseUrl + `cart/${userId}`)
  }

  UpdateitemInCart(productId :number, quantity: number = 1, userId: string)
  {
    const itemUpdateObj: any = {
      userId: userId,
      productId: productId,
      quantity: quantity
    }

    // return this.http.post<CartItem>(this.baseUrl + 'cart',itemUpdateObj).pipe(
    //   map(
    //     response =>{
    //       if(response !== null)
    //       {
    //         this.currentCartSource.pipe(
    //           map(data => data?.items.map(item =>
    //             item.id === response.id? {...item,quantity:response.quantity}:item))
    //         )
    //       }
    //       else
    //       {
    //         this.currentCartSource.pipe(
    //           map(data => data?.items.filter(item =>
    //             item.productId !== productId
    //           ))
    //         )
    //       }
    //     }
    //   )
    // )

    return this.http.post<CartItem>(this.baseUrl + 'cart',itemUpdateObj)
  }

  RemoveItemFromCart(productId :number, userId:string)
  {
    return this.http.delete<boolean>(this.baseUrl + `cart/${userId}/${productId}`)
  }

  DeleteCart(userId: string)
  {
    return this.http.delete<boolean>(this.baseUrl + `${userId}`)
  }

  SetCart(cart: Cart)
  {
    this.currentCartSource.next(cart)
  }

  clearCart()
  {
    this.currentCartSource.next(null)
  }

  get GetCart(): Cart | null
  {
    return this.currentCartSource.value
  }
}
