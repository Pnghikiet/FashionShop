import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ProductBrand } from '../../shared/models/productbrand.model';
import { ProductType } from '../../shared/models/producttype.model';
import { ProductSubType } from '../../shared/models/productsubtype.model';
import { Param } from '../../shared/models/param.model';
import { Pagination } from '../../shared/models/pagination.model';
import { Product } from '../../shared/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = environment.apiUrl
  productParam: Param

  constructor(private http: HttpClient) { 
    this.productParam = new Param()
  }
  
  getProductParam()
  {
    return this.productParam
  }

  setPorductParam(productParam: Param)
  {
    this.productParam = productParam
  }

  getProductById(id: number)
  {
    return this.http.get<Product>(this.baseUrl + `product/${id}`)
  }

  getProducts()
  {
    let params =new HttpParams()

    if(this.productParam.brandid)
      params = params.append('BrandId', this.productParam.brandid)

    if(this.productParam.typeId)
      params = params.append('TypeId', this.productParam.typeId)

    if(this.productParam.subTypeId)
      params = params.append('SubTypeId', this.productParam.subTypeId)
    
    if(this.productParam.search)
      params = params.append('Search', this.productParam.search)

    if(this.productParam.gender)
      params = params.append('Gender', this.productParam.gender)
    
    params = params.append('PageIndex',this.productParam.pageIndex)
    params = params.append('PageSize',this.productParam.pageSize)
    params = params.append('sort',this.productParam.sort)


    return this.http.get<Pagination<Product>>(this.baseUrl + 'product',{params})
  }

  getBrands()
  {
    return this.http.get<ProductBrand[]>(this.baseUrl + 'product/brands')
  }

  getTypes()
  {
    return this.http.get<ProductType[]>(this.baseUrl + 'product/types')
  }

  getSubTypes()
  {
    return this.http.get<ProductSubType[]>(this.baseUrl + `product/subtypes/`)
  }
}
