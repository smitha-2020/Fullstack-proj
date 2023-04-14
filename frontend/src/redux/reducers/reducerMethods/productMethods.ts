import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosError, AxiosResponse } from 'axios';
import axiosInstance from '../../../common/axiosInstance';
import { IProduct, IProductBase, IProductBaseCreate, IProductCreateResponse, IProductModify, imageLink } from '../../../types/productType';

var imagesId:number[] = [];
var imagesArr:imageLink[] = []
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
        imagesId = [];
        try { 
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
            if(productId){
                const AssignResponse: AxiosResponse<any, any> = await axiosInstance.post(`images/${productId}/assign`, {"images":imagesId},{ headers: {'Authorization': `Bearer ${userJson}`}})
                const result: AxiosResponse<any, IProduct> = await axiosInstance.get(`products/${productId}`);
                return result.data;
            }
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

//step1: updating an array of imageArr
const updateLink = async (id:number,link:string) => {
    try {
      var imageData ={"imageURL":link}
      const response = await axiosInstance.put(`images/${id}`, imageData,{ headers: {'Authorization': `Bearer ${userJson}`} } );
      imagesArr.push(response.data);
    } catch (error) {
      console.log(error);
    }
  };
export const modifyProduct = createAsyncThunk(
    "modifyProduct",
    async ({ id, updateProduct,images }: IProductModify) => {
        console.log(updateProduct)
        var imageLink;
        try{
            imagesArr = [];
            var i = 0;
            var response = await axiosInstance.get(`/products/${id}/productimages`,{ headers: {'Authorization': `Bearer ${userJson}`}});
            imageLink = response.data;
            console.log("reposne",imageLink)
            // var responsecategory = await axiosInstance.get(`/categorys/${}`,{ headers: {'Authorization': `Bearer ${userJson}`}});
            // console.log("responsecategory",responsecategory.data)
            if(images.length === 3){
                for(const link of response.data){
                    await updateLink(link.id,images[i]);
                    i++;
                } 
            }
            if(updateProduct && images.length === 3){
                const response = await axiosInstance.put(`products/${id}`, updateProduct,{ headers: {'Authorization': `Bearer ${userJson}`} } );
                return {...response.data,imageLink:[...imagesArr]};
            }
            if(updateProduct){
                const response = await axiosInstance.put(`products/${id}`, updateProduct,{ headers: {'Authorization': `Bearer ${userJson}`} } );
                return {...response.data,imageLink:[...imageLink]};
            }
        }
        catch(e){
            console.log(e)
        }
    }
)