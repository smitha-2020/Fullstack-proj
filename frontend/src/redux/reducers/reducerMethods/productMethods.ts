import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosError, AxiosResponse } from 'axios';
import axiosInstance from '../../../common/axiosInstance';
import { IProduct, IProductBase, IProductBaseCreate, IProductCreateResponse, IProductModify } from '../../../types/productType';

var imagesId:number[] = [];
const userJson = localStorage.getItem('accessToken');
export const fetchAllProducts = createAsyncThunk(
    "fetchAllProducts",
    async () => {
        try {
            const response: AxiosResponse<any, IProduct[]> = await axiosInstance.get("products/all",
            {
                headers: {
                "Access-Control-Allow-Origin": "*",
                'Content-Type': 'application/json'
                }}
         )
            return response.data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
//step1: creating an array of imagesId
const insertLink = async (link:string) => {
    try {
      var imageData ={"imageURL":link}
      const response = await axiosInstance.post("images", imageData,{ headers: {'Authorization': `Bearer ${userJson}`} } );
      imagesId.push(response.data.id);
    } catch (error) {
      console.log(error);
    }
  };

export const addingProduct = createAsyncThunk(
    "addingProduct",
    async (product: IProductBase) => {
        try { 
            console.log("hiiiiiiiiiiiiiiiiiiii")
            var productData:IProductBase = {
                title: '',
                price: 0,
                description: '',
                categoryId: 0,
                imagestr: []
            };
            var productCreate:IProductBaseCreate={
                title: '',
                price: 0,
                description: '',
                categoryId: 0
            }
            if(product.imagestr.length===3){
            for(const link of product.imagestr){
                await insertLink(link);
            }   
            //2.create productobj to insert into db
            productCreate={"title":product.title,"description":product.description,"price":product.price,"categoryId":product.categoryId}
            productData = {...productData,"title":product.title,"description":product.description,"price":product.price,"categoryId":product.categoryId}
            //3.Insert obj to database.
            const response: AxiosResponse<any, IProductCreateResponse> = await axiosInstance.post("products", productCreate,{ headers: {'Authorization': `Bearer ${userJson}`} })
            const productId = response.data.id;
            //4.Assign images to product
            const AssignResponse: AxiosResponse<any, any> = await axiosInstance.post(`images/${productId}/assign`, {"images":imagesId},{ headers: {'Authorization': `Bearer ${userJson}`}})
            const result: AxiosResponse<any, IProduct> = await axiosInstance.get(`products/${productId}`);
            return result.data;
        }
        }
        catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)

export const fetchAllProductsbyCategory = createAsyncThunk(
    "fetchAllProductsbyCategory",
    async (id: number) => {
        try {
            const response: AxiosResponse<any, IProduct[]> = await axios.get(`categorys/${id}/products`)
            return response.data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
// export const fetchProductsByPagination = createAsyncThunk(
//     "fetchProductsByPagination",
//     async (currentPage: number) => {
//         try {
//             const response: AxiosResponse<any, IProduct[]> = await axios.get(`https://api.escuelajs.co/api/v1/products?offset=${currentPage}&limit=12`)
//             return response.data
//         } catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     }
// )
export const getSingleProduct = createAsyncThunk(
    "getSingleProduct",
    async (productId: number) => {
        let url = `products/${productId}`;
        try {
            const response: AxiosResponse<any, IProduct> = await axiosInstance.get(url)
            return response.data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
export const deletingProduct = createAsyncThunk(
    "deletingProduct",
    async (id: number) => {
        try {
            const response:AxiosResponse<boolean, any>  = await axiosInstance.delete(`products/${id}`,{ headers: {'Authorization': `Bearer ${userJson}`} })
            const dataReturn = response.data ? id : 0;
            return dataReturn;
        }
        catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)

//step1: creating an array of imagesId
const updateLink = async (id:number,link:string) => {
    try {
      var imageData ={"imageURL":link}
      const response = await axiosInstance.put(`images/${id}`, imageData,{ headers: {'Authorization': `Bearer ${userJson}`} } );
    } catch (error) {
      console.log(error);
    }
  };
export const modifyProduct = createAsyncThunk(
    "modifyProduct",
    async ({ id, updateProduct,images }: IProductModify) => {
        try {
            var i =0;
            const response: AxiosResponse<any, IProduct> = await axiosInstance.get(`products/${id}`,{ headers: {'Authorization': `Bearer ${userJson}`} })
            
            for(const link of response.data.imageLink){
                await updateLink(link.id,images[i]);
                i++;
            }
            return response.data
            // const response: AxiosResponse<IProduct, any> = await axios.put(`https://api.escuelajs.co/api/v1/products/${id}`, updateProduct)
            // return response.data
        } catch (e) {
            console.log(e)
        }
    }
)