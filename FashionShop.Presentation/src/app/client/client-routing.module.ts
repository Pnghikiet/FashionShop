import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './client.component';
import { HomeComponent } from './home/home.component';
import { authGuard } from './guard/auth.guard';

const routes : Routes = [
  {path:'',component:ClientComponent,
    children:[
      {path:'',component:HomeComponent},
      {path:'products',loadChildren: () => import('./product/product.module').then(m => m.ProductModule)},
      {path:'account',loadChildren:() => import('./account/account.module').then(m => m.AccountModule)},
      {path:'cart',loadChildren:() => import('./cart/cart.module').then(m => m.CartModule),canActivate:[authGuard]}
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class ClientRoutingModule { }
