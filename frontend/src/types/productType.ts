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
    category: ICategory,
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
export interface IProductBase{
    title: string,
    price: number,
    description: string,
    categoryId: number,
    imagestr:string[]
}
export interface IProductNew extends IProductBase{
    images: any[]
}
export interface IProductDetails{
    product:IProduct[],
    totalCount:number,
    isDone:boolean
}
export interface IProductOpt {
    id: number,
    title?: string,
    price?: number,
    description?: string,
    images?: imageLink[],
    categoryId?: number,
}
export interface IProductModify {
    id: number,
    updateProduct:Partial<IProduct>
}