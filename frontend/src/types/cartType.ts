import { IAuthenticUser } from "./userType"
import { IProduct } from './productType'
export interface ICart {
    quantity: number,
    product: IProduct
    userInfo: IAuthenticUser
}