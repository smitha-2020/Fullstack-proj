import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ICategory } from '../../../types/productType';

export const fetchAllCategories = createAsyncThunk(
    "fetchAllCategories",
    async () => {
        try {
            const res = await axios.get("https://localhost:5001/categorys", {
                headers: {
                "Access-Control-Allow-Origin": "*",
                  'Content-Type': 'application/json'
                }
              })
            return res.data;
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
// export const getSingleCategory = createAsyncThunk(
//     "getSingleCategory",
//     async (id: string) => {
//         try {
//             const res: AxiosResponse<ICategory[], any> = await axios.get(`https://api.escuelajs.co/api/v1/categories/${id}`);
//             return res.data;
//         }
//         catch (e) {
//             const error = e as AxiosError
//             return error
//         }
//     })
export const createCategory = createAsyncThunk(
    "createCategory",
    async (category: ICategory) => {
        try {
            const res: AxiosResponse<ICategory, any> = await axios.post('https://localhost:5001/products', category)
            return res.data;
        }
        catch (e) {
            const error = e as AxiosError
            return error
        }
    })
//     export const updateCategory = createAsyncThunk(
//         "updateCategory",
//         async (data: ICategory) => {
//             const { id, ...filteredCategory } = data
//             try {
//                 const res: AxiosResponse<ICategory, any> = await axios.put(`https://api.escuelajs.co/api/v1/categories/${id}`, filteredCategory)
//                 //console.log(res.data)
//                 return res.data;
//             }
//             catch (e) {
//                 const error = e as AxiosError
//                 return error
//             }
//         }
//     )
//     export const deleteCategory = createAsyncThunk(
//         "deleteCategory",
//         async (id: number) => {
//             const res: AxiosResponse<boolean, any> = await axios.delete(`https://api.escuelajs.co/api/v1/categories/${id}`)
//             const result = res.data ? id : 0
//             return result
//         }
//     )

