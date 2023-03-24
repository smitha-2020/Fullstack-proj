import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { IProduct, IProductDesc, IProductModify } from '../../../types/productType';

export const fetchAllProducts = createAsyncThunk(
    "fetchAllProducts",
    async () => {
        try {
            const response: AxiosResponse<any, IProduct[]> = await axios.get("https://localhost:5001/products/all",
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
// export const fetchAllProductsbyCategory = createAsyncThunk(
//     "fetchAllProductsbyCategory",
//     async (id: number) => {
//         try {
//             const response: AxiosResponse<any, IProduct[]> = await axios.get(`https://api.escuelajs.co/api/v1/categories/${id}/products`)
//             return response.data
//         } catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     }
// )
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
// export const getSingleProduct = createAsyncThunk(
//     "getSingleProduct",
//     async (productId: string) => {
//         let url = `https://api.escuelajs.co/api/v1/products/${productId}`;
//         try {
//             const response: AxiosResponse<any, IProduct> = await axios.get(url)
//             return response.data
//         } catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     }
// )
// export const addingProduct = createAsyncThunk(
//     "addingProduct",
//     async (product: IProductDesc) => {
//         try {
//             //const responseImg = await axios.post("https://api.escuelajs.co/api/v1/files/upload", { 'file': product.imagestr[0] }, { headers: { 'Content-Type': 'multipart/form-data' } })
//             // if (responseImg.data) {
//             //const response: AxiosResponse<Product, Product> = await axios.post("https://api.escuelajs.co/api/v1/products/", product)
//             const response: AxiosResponse<IProduct, any> = await axios.post("https://api.escuelajs.co/api/v1/products", product)
//             return response.data
//         }
//         catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     }
// )
// export const deletingProduct = createAsyncThunk(
//     "deletingProduct",
//     async (id: number) => {
//         try {
//             const response:AxiosResponse<boolean, any>  = await axios.delete(`https://api.escuelajs.co/api/v1/products/${id}`)
//             const dataReturn = response.data ? id : 0;
//             return dataReturn;
//         }
//         catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     }
// )
// export const modifyProduct = createAsyncThunk(
//     "modifyProduct",
//     async ({ id, updateProduct }: IProductModify) => {
//         try {
//             const response: AxiosResponse<IProduct, any> = await axios.put(`https://api.escuelajs.co/api/v1/products/${id}`, updateProduct)
//             return response.data
//         } catch (e) {
//             console.log(e)
//         }
//     }
// )