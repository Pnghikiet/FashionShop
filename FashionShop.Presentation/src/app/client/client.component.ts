import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent implements OnInit{

  constructor(private accountService : AccountService){}

  ngOnInit(): void {
    this.LoadCurrentUser()
  }

  LoadCurrentUser()
  {
    const token = localStorage.getItem('token')
    if(token) this.accountService.LoadCurrentUser().subscribe()
  }
}
