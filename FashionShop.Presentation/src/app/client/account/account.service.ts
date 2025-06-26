import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from '../../shared/models/user.model';
import { BehaviorSubject, map } from 'rxjs';
import { Router } from '@angular/router';
import { CartService } from '../cart/cart.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl
  private currentUserSource = new BehaviorSubject<User | null>(null)
  currentUSer$ = this.currentUserSource.asObservable()

  constructor(private http: HttpClient, private router: Router,
    private cartService: CartService
  ) { }

  Login(value:any)
  {
    console.log(value)
    return this.http.post<User>(this.baseUrl + 'account/login',value).pipe(
      map(response =>{
        localStorage.setItem('token',response.token)
        this.currentUserSource.next(response)
      })
    )
  }

  Register(value:any)
  {
    return this.http.post<User>(this.baseUrl + 'account/register',value).pipe(
      map(response =>{
        localStorage.setItem('token',response.token)
        this.currentUserSource.next(response)
      })
    )
  }

  Logout()
  {
    localStorage.removeItem('token')
    this.currentUserSource.next(null)
    this.cartService.SetCart(null)
    this.ReloadCurrentRoute()
  }

  LoadCurrentUser()
  {
    return this.http.get<User>(this.baseUrl + 'account').pipe(
      map(response => {
        this.currentUserSource.next(response)
      })
    )
  }

  ReloadCurrentRoute()
  {
    const currentRoute = this.router.url

    this.router.navigateByUrl('/',{skipLocationChange: true}).then(() => {
      this.router.navigate([currentRoute])
    })
  }
}
