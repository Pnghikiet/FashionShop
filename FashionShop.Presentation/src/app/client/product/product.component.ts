import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ProductService } from './product.service';
import { Param } from '../../shared/models/param.model';
import { ProductBrand } from '../../shared/models/productbrand.model';
import { ProductType } from '../../shared/models/producttype.model';
import { Product } from '../../shared/models/product.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductSubType } from '../../shared/models/productsubtype.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{

  products!: Product[]
  brandSelectOptions: ProductBrand[] = []
  typeSelectOptions: ProductType[]  = []
  subTypeSelectOptions: ProductSubType[] = []
  @ViewChild('search') SearchInput! : ElementRef
  params: any = {}

  genderSelectOptions = [
    {name:'Giới tính',value:null},
    {name:'Nam',value:'Male'},
    {name:'Nữ',value:'Female'}
  ]

  sortSelectoptions=[
    {name:'A-Z',value:'asc'},
    {name:'Z-A',value:'desc'},
    {name:'Giá tiền tăng',value:'priceasc'},
    {name:'Giá tiền giảm',value:'pricedesc'}
  ]

  productParam:Param
  totalItem!: number


  constructor(private productService: ProductService, private route: Router,
    private activatedRoute : ActivatedRoute
  )
  {
    this.productParam = this.productService.getProductParam()
  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params =>{
      if(params['sort'] && this.sortSelectoptions.includes(params['sort']))
        this.productParam.sort = params['sort']
      if(params['gender'] && this.genderSelectOptions.includes(params['gender']))
        this.productParam.gender = params['gender']
      if(params['brand'] && this.brandSelectOptions.includes(params['brand']))
        this.productParam.brandid = params['brand']
      if(params['type'] && this.typeSelectOptions.includes(params['type']))
        this.productParam.typeId = params['type']
      if(params['subtype'] && this.subTypeSelectOptions.includes(params['subtype']))
        this.productParam.subTypeId = params['subtype']
      if(params['search'])
        this.productParam.search = params['search']
    })
    this.getProduct()
    this.getBrands()
    this.getType()
    this.getSubtype()
  }

  getBrands()
  {
    this.productService.getBrands().subscribe(response => 
      this.brandSelectOptions = [{id: 0,name:'Hãn sản phẩm'}, ...response]
    )
  }

  getType()
  {
    this.productService.getTypes().subscribe(response =>
      this.typeSelectOptions = [{id:0,name:'Kiểu sản phẩm'},...response]
    )
  }

  getProduct()
  {
    this.productService.getProducts().subscribe(response =>{
      this.totalItem = response.totalItem
      this.products = response.data
    })
  }

  getSubtype()
  {
    this.productService.getSubTypes().subscribe(response =>
      this.subTypeSelectOptions = [{id:0,name:'Thể Loại',productType:0},...response]
    )
  }

  onPageChanged(event:any)
  {
    if(event !== this.productParam.pageIndex)
    {
      this.productParam.pageIndex = event
      this.productService.setPorductParam(this.productParam)
      this.getProduct()
    }
  }

  onSortSelected(event: Event)
  {
    let sort = event.target as HTMLInputElement
    this.productParam.sort = sort.value
    this.productService.setPorductParam(this.productParam)
    this.params['sort'] = sort.value
    this.addToQueryParam(this.params)
    this.getProduct()
  }

  onSelected(event:Event,sortType:string)
  {
    const selectedoptions = event.target as HTMLInputElement

    if(sortType === 'gender')
    {
      this.productParam.gender = selectedoptions.value === 'null' ? '' : selectedoptions.value
    }
    if(sortType === 'subtype')
    {
      const subTypeId = parseInt(selectedoptions.value)
      this.productParam.subTypeId = subTypeId === 0 ? undefined : subTypeId
    }
    if(sortType === 'type')
    {
      const typeId = parseInt(selectedoptions.value)
      this.productParam.typeId = typeId === 0 ? undefined : typeId
    }
    if(sortType === 'brand')
    {
      const brandId = parseInt(selectedoptions.value)
      this.productParam.brandid = brandId === 0 ? undefined : brandId
    }
  }

  addToQueryParam(param:any)
  {
    this.route.navigate([],{
      queryParams:param,
      queryParamsHandling:'merge'
    })
  }

  onSearch()
  {
    const searchInput = this.SearchInput.nativeElement.value
    if(searchInput)
    {
      this.productParam.search = searchInput
      this.params['search'] = searchInput
    }
    this.params['brand'] = this.productParam.brandid?.toString()
    this.params['type'] = this.productParam.typeId?.toString()
    this.params['subtype'] = this.productParam.subTypeId?.toString()
    this.params['gender'] = this.productParam.gender
    this.addToQueryParam(this.params)
    this.productParam.pageIndex = 1
    this.productService.setPorductParam(this.productParam)
    this.getProduct()
    
  }

  onReset()
  {
    this.productParam = new Param()
    this.productService.setPorductParam(this.productParam)
    this.route.navigate([],{
      queryParams:{},
      queryParamsHandling:''
    })
    this.getProduct()

  }
}
