import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../shared/models/product.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit{
  product?: Product
  quantity = 1

  constructor(private productService : ProductService, private activeRoute: ActivatedRoute){}
  
  ngOnInit(): void {
    this.getProductById()
  }
  

  getProductById()
  {
    const id = this.activeRoute.snapshot.paramMap.get('id')
    if(id)
    {
      this.productService.getProductById(+id).subscribe(response => {
        this.product = response
      },
    error => console.log(error))
    }
  }
}
