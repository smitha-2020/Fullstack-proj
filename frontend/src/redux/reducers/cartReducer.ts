import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { ICart } from '../../types/cartType'

const initialState: ICart[] = [];
const cartSlice = createSlice({
    name: 'productSlice',
    initialState: initialState,
    reducers: {
        addToCart(state, action: PayloadAction<ICart>) {
            const existingData = state.filter((cartElement) => { return cartElement.product.id === action.payload.product.id })
            if (existingData.length) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.product.id === action.payload.product.id) {
                        quantity = (cartElement.quantity + action.payload.quantity) >= Number(5) ? Number(5) : (cartElement.quantity + action.payload.quantity);
                        return { ...cartElement, quantity }
                    } else {
                        return cartElement
                    }
                })
             
                return datanew;
            } else {
                return [...state, action.payload]
            }
        },
        removeFromCart(state, action) {
            const newCart = state.filter((cartElement) => { return cartElement.product.id !== action.payload })
            return [...newCart]
        },
        removeCart(state,action) {
            const newCart = state.filter((cartElement) => { return cartElement.userInfo.id! === action.payload })
            return newCart;
        },
        increaseQuantity(state, action) {
            const existingData = state.filter((cartElement) => { return cartElement.product.id === action.payload })
            if (existingData.length) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.product.id === action.payload) {
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
            const existingData = state.filter((cartElement) => { return cartElement.product.id === action.payload })
            if (existingData.length) {
                const datanew = state.map((cartElement) => {
                    let quantity
                    if (cartElement.product.id === action.payload) {
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
})
const cartReducer = cartSlice.reducer;
export default cartReducer;

export const { addToCart, removeFromCart, removeCart, increaseQuantity, decreaseQuantity } = cartSlice.actions;