import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from '../../shared/models/user.model';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl
  private currentUserSource = new BehaviorSubject<User | null>(null)
  currentUSer$ = this.currentUserSource.asObservable()

  constructor(private http: HttpClient) { }

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
  }

  LoadCurrentUser()
  {
    return this.http.get<User>(this.baseUrl + 'account').pipe(
      map(response => {
        this.currentUserSource.next(response)
      })
    )
  }
}
