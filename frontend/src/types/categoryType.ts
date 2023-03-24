import { ICategory } from "./productType"
export interface ICategoryModify{
    id:number,
    updateCategory:Partial<ICategory>
}
export interface ICategoryAdd{
    updateCategory:Partial<ICategory>
}
