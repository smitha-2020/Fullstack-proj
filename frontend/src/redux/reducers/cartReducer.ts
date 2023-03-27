import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { AxiosError } from 'axios';
import { ICart, ICartOp, ICartResponse, ICartType } from '../../types/cartType'
import { addingToCart, fetchCartDetails } from './reducerMethods/cartMethod';

const initialState: ICartType[] = [];
const cartSlice = createSlice({
    name: 'cartSlice',
    initialState: initialState,
    reducers: {
        addToCart(state, action: PayloadAction<ICartType>) {
            console.log('smitha',action.payload)
            const existingData = state.filter((cartElement) => { return (cartElement.products.id === action.payload.products.id && cartElement.userId.sub === action.payload.userId.sub) })     
            if (existingData.length>0) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.products.id === action.payload.products.id) {
                        quantity = (cartElement.quantity + action.payload.quantity) >= Number(5) ? Number(5) : (cartElement.quantity + action.payload.quantity);
                        return { ...cartElement, quantity:quantity }
                    } else {
                        return cartElement
                    }
                })
                return datanew;
            } 
            return [...state,action.payload];
        },
        removeFromCart(state, action) {
            const newCart = state.filter((cartElement) => { return cartElement.products.id !== action.payload })
            return newCart;
        },
        removeCart(state,action) {
            const newCart = state.filter((cartElement) => { return cartElement.userId! === action.payload })
            return newCart;
        },
        increaseQuantity(state, action:PayloadAction<ICartOp>) {
            const existingData = state.filter((cartElement) => { return cartElement.products.id === action.payload.id })
            if (existingData) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.products.id === action.payload.id && cartElement.userId.sub === action.payload.authentication.sub && action.payload.authentication.sub!==undefined) {
                        quantity = (cartElement.quantity + 1) >= Number(5) ? Number(5) : (cartElement.quantity + 1);
                        return { ...cartElement, quantity }
                    } 
                    else {
                        return cartElement
                    }
                })
                return datanew;
            }
        },
        decreaseQuantity(state, action:PayloadAction<ICartOp>) {
            const existingData = state.filter((cartElement) => { return cartElement.products.id === action.payload.id })
            if (existingData) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.products.id === action.payload.id && cartElement.userId.sub === action.payload.authentication.sub && action.payload.authentication.sub!==undefined) {
                        quantity = (cartElement.quantity - 1) <= Number(1) ? Number(1) : (cartElement.quantity - 1);
                        return { ...cartElement, quantity }
                    } else {
                        return cartElement
                    }
                })
                return datanew;
            }
        }
    }
    // ,
    // extraReducers: (build) => {
    //     build.addCase(fetchCartDetails.fulfilled, (state, action) => {
    //         if (action.payload instanceof AxiosError) {
    //             return state;
    //         }
    //         return action.payload
    //     })
    //     .addCase(addingToCart.fulfilled, (state, action) => {
    //         if (action.payload instanceof AxiosError) {
    //             return state;
    //         }
    //         return action.payload
    //     })
    // }
})
const cartReducer = cartSlice.reducer;
export default cartReducer;

export const { addToCart,increaseQuantity,decreaseQuantity,removeCart,removeFromCart } = cartSlice.actions;