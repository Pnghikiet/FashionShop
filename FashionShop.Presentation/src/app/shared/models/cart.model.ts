import { CartItem } from "./cartitem.model"

export interface Cart {
  id: string
  userId: string
  items: CartItem[]
}