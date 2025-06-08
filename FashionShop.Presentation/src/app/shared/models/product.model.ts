import { ProductSubType } from "./productsubtype.model"

export interface Product{
    id: number
    name: string
    description: string
    price: number
    imageUrl: string
    gender: string
    productSubType: ProductSubType
    productBrand: string
}