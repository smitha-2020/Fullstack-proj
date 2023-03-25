import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError, AxiosResponse } from "axios";
import { ICart, ICartInput, ICartResponse } from "../../../types/cartType";

export const fetchCartDetails = createAsyncThunk(
    "fetchCart",
    async () => {
        try {
            const response = await axios.get("https://localhost:5001/carts")
            return response.data;
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)

export const addingToCart = createAsyncThunk(
    "addingToCart",
    async (cart:ICartInput) => {
        try {
            const id = cart.ProductId;
            const userId = cart.userId;
            let totalQuantity=0;
            console.log(userId)
            const responseCartItemAvailable:AxiosResponse<boolean,any> = await axios.get(`https://localhost:5001/carts/isavailable/${cart.ProductId}`)
            const userCart = await axios.get(`https://localhost:5001/carts/${userId}/products`)
            if(!responseCartItemAvailable.data){
                const response= await axios.post("https://localhost:5001/carts", cart)
                return response.data
            }
            userCart.data.forEach((element: any) => {
                totalQuantity+=element.quantity;
            });
            console.log(totalQuantity)
            if((totalQuantity+cart.quantity)<=5){
                console.log("hi")
                const response= await axios.post("https://localhost:5001/carts", cart)
                return response.data
            }
            const newCartQuantity = (5-(totalQuantity))
            if(newCartQuantity>0){
                const response= await axios.post("https://localhost:5001/carts", {...cart,quantity:newCartQuantity})
                return response.data
            }
        }
        catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)