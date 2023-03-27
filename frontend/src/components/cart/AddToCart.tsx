import React, { useState } from 'react'
import { Button } from "@mui/material";
import ToggleButton from './ToggleButton';
import styled from "@emotion/styled";
import { NavLink, useNavigate } from 'react-router-dom';

import { IProduct } from '../../types/productType';
import {ICartType, ICartInput, ICartResponse} from '../../types/cartType';
import { IAuthenticUser } from '../../types/userType';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
//import { addingToCart } from '../../redux/reducers/reducerMethods/cartMethod';
import { addToCart } from '../../redux/reducers/cartReducer';
import { SubmitHandler } from 'react-hook-form';


const AddToCart = ({ products,id }: { products: IProduct,id:string }) => {
    const ButtonNew = styled(Button)({
        backgroundColor: "darkgray",
        color: "white",
        marginTop: "20px"
    });
    //const cart = useAppSelector(state => { return state.cartReducer; })
    const authentication: IAuthenticUser = useAppSelector(state => state.auhtReducer)
    const dispatch = useAppDispatch();
    const stock = 5;
    const [amount, setAmount] = useState(1)
    const setIncrease = () => {
        amount < stock ? setAmount(amount + 1) : setAmount(stock)
    }
    const setDecrease = () => {
        amount > 1 ? setAmount(amount - 1) : setAmount(1)
    }
    const CartBtn = styled(Button)({
        marginTop: "20px",
        backgroundColor: "lightblue",
        color: "gray"
    });
    const data: ICartType = {
        quantity: amount,
        products: products,
        userId:authentication
    }
    const addCart = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
        if(data.userId.sub === authentication.sub){
            dispatch(addToCart(data))  
        }
    }
    return (
        <>
            <ToggleButton amount={amount} setIncrease={setIncrease} setDecrease={setDecrease} />
            <NavLink to="/cart" onClick={(e) => { addCart(e) }}>
                <Button variant='contained' style={{backgroundColor: "darkgray",color: "white",marginTop: "20px"}}>Add To Cart</Button>
            </NavLink>
        </>
    )
}

// const AddToCart = ({ products,id,userId }: { products: IProduct,id:string,userId:string }) => {
//     const ButtonNew = styled(Button)({
//         backgroundColor: "darkgray",
//         color: "white",
//         marginTop: "20px"
//     });
//     const cart = useAppSelector(state => { return state.cartReducer; })
//     const authentication: IAuthenticUser = useAppSelector(state => state.auhtReducer)
//     const dispatch = useAppDispatch();
//     const stock = 5;
//     const [amount, setAmount] = useState(1)
//     const setIncrease = () => {
//         amount < stock ? setAmount(amount + 1) : setAmount(stock)
//     }
//     const setDecrease = () => {
//         amount > 1 ? setAmount(amount - 1) : setAmount(1)
//     }
//     const CartBtn = styled(Button)({
//         marginTop: "20px",
//         backgroundColor: "lightblue",
//         color: "gray"
//     });
//     var authenticatedUser = authentication.sub;

//     // function handleClick() {
//     //     let cartItem:ICartInput = {
//     //         userId: userId,
//     //         ProductId: id,
//     //         quantity:amount
//     //     }
//     //     dispatch(addingToCart(cartItem));
       
//     //   }

//     // const data: ICart = {
//     //     quantity: amount,
//     //     product: products,
//     //     userInfo:authentication
//     // }
//     const addCart = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
//         let cartItem:ICartInput = {
//             userId: userId,
//             ProductId: id,
//             quantity:amount
//         }
//          console.log({...cartItem})
//          dispatch(addingToCart(cartItem)); 

//     }
//     return (
//         <>
//             <ToggleButton amount={amount} setIncrease={setIncrease} setDecrease={setDecrease} />
//             <NavLink to="/cart" onClick={(e) => { addCart(e) }}> 
//                 <Button variant='contained' style={{backgroundColor: "darkgray",color: "white",marginTop: "20px"}} >Add To Cart</Button>
//             </NavLink>
//         </>
//     )
// }

export default AddToCart