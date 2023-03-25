import { IAuthenticUser, IUserResponse } from "./userType";
import { IProduct } from "./productType";
// export interface ICart {
//     quantity: number,
//     product: IProduct
//     userInfo: IAuthenticUser
// }

export interface ICart {
  quantity: number;
  product: IProduct;
  userId: string;
}

export interface ICartInput {
  userId: string;
  ProductId: string;
  quantity: number;
}

export interface ICartResponse {
  id:number,
  userId: string,
  quantity: number,
  products:IProduct,
  ProductId: string;
  users:IUserResponse
}
