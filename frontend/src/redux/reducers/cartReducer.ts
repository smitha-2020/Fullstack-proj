import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { AxiosError } from 'axios';
import { ICart, ICartResponse } from '../../types/cartType'
import { addingToCart, fetchCartDetails } from './reducerMethods/cartMethod';

const initialState: ICartResponse[] = [];
const cartSlice = createSlice({
    name: 'cartSlice',
    initialState: initialState,
    reducers: {
        // addToCart(state, action: PayloadAction<ICart>) {
        //     const existingData = state.filter((cartElement) => { return cartElement.product.id === action.payload.product.id })
        //     if (existingData.length) {
        //         const datanew = state.map((cartElement) => {
        //             let quantity
        //             if (cartElement.product.id === action.payload.product.id) {
        //                 quantity = (cartElement.quantity + action.payload.quantity) >= Number(5) ? Number(5) : (cartElement.quantity + action.payload.quantity);
        //                 return { ...cartElement, quantity }
        //             } else {
        //                 return cartElement
        //             }
        //         })
             
        //         return datanew;
        //     } else {
        //         return [...state, action.payload]
        //     }
        // },
        // removeFromCart(state, action) {
        //     const newCart = state.filter((cartElement) => { return cartElement.product.id !== action.payload })
        //     return [...newCart]
        // },
        // removeCart(state,action) {
        //     const newCart = state.filter((cartElement) => { return cartElement.userInfo.id! === action.payload })
        //     return newCart;
        // },
        increaseQuantity(state, action) {
            const existingData = state.filter((cartElement) => { return cartElement.products.id === action.payload })
            if (existingData.length) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.products.id === action.payload) {
                        quantity = (cartElement.quantity + 1) >= Number(5) ? Number(5) : (cartElement.quantity + 1);
                        return { ...cartElement, quantity }
                    } else {
                        return cartElement
                    }
                })
                return datanew;
            }
        },
        decreaseQuantity(state, action) {
            const existingData = state.filter((cartElement) => { return cartElement.products.id === action.payload })
            if (existingData.length) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.products.id === action.payload) {
                        quantity = (cartElement.quantity - 1) <= Number(1) ? Number(1) : (cartElement.quantity - 1);
                        return { ...cartElement, quantity }
                    } else {
                        return cartElement
                    }
                })
                return datanew;
            }
        }
    },
    extraReducers: (build) => {
        build.addCase(fetchCartDetails.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state;
            }
            return action.payload
        })
        .addCase(addingToCart.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state;
            }
            return action.payload
        })
    }
})
const cartReducer = cartSlice.reducer;
export default cartReducer;

export const { increaseQuantity, decreaseQuantity } = cartSlice.actions;