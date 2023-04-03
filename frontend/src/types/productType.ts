export interface ICategory {
    id: number,
    name: string,
    image: string
}
export interface IProduct {
    id: number,
    title: string,
    price: number,
    description: string,
    imageLink: imageLink[],
    category: ICategory
}
export interface imageLink {
    id: number,
    imageURL:string
}
export interface IProductDesc {
    title: string,
    price: number,
    description: string,
    categoryId: number,
    images: string[]
}
// export interface IProductBase{
//     title: string,
//     price: number,
//     description: string,
//     categoryId: number,
//     imagestr1:string,
//     imagestr2:string,
//     imagestr3:string
// }
export interface IProductBase{
    title: string,
    price: number,
    description: string,
    categoryId: number,
    imagestr:string[]  
}

export interface IProductBaseCreate{
    title: string,
    price: number,
    description: string,
    categoryId: number
}
export interface IProductNew extends IProductBase{
    images: any[]
}
export interface IProductDetails{
    product:IProduct[],
    totalCount:number,
    isDone:boolean,
    isLoading:boolean,
    isSuccess:boolean
}
export interface IImageBase{
    imageURL: string
}
export interface IImageResponse{
    id: number,
    imageURL: string
}
export interface IProductOpt {
    id: number,
    title?: string,
    price?: number,
    description?: string,
    categoryId?: number
}
export interface IProductModify {
    id: number,
    updateProduct:Partial<IProduct>
    images:string[]
}

export interface IProductImage{
    imagestr:string[]
}
export interface IProductCreateResponse{
    id: number,
    title: string,
    price: number,
    description: string,
    categoryId: number,
    category: ICategory,
    imageLink: imageLink[]
}