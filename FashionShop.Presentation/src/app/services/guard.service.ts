import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  GetToken() : string | null
  {
    return localStorage.getItem('token')
  }

  GetDecodedToken() : any
  {
    const token = this.GetToken()

    return token? jwtDecode(token) : null
  }
  

  GetUserId()
  {
    const decodedToken = this.GetDecodedToken()
    
    return decodedToken? decodedToken?.nameid : null
  }

  GetRoles()
  {
    const decodedToken = this.GetDecodedToken()

    return decodedToken? decodedToken?.role : null
  }

  IsTokenExpired(): boolean
  {
    const decodedToken = this.GetDecodedToken()

    const expiryDate = this.GetTokenExpireDate(decodedToken)

    if(!expiryDate)
      return true

    return expiryDate.valueOf() < new Date().valueOf()
  }

  private GetTokenExpireDate(decodedToken: any): Date | null
  {
    if(!decodedToken.exp)
      return null

    const date = new Date(0)

    date.setUTCSeconds(decodedToken?.exp)
    return date
  }
}
