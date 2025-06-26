import { Component } from '@angular/core';
import { AccountService } from '../../account/account.service';
import { CartService } from '../../cart/cart.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {


  constructor(public accountService: AccountService, public cartService: CartService){}
}
