import { Grid } from "@mui/material";
import { FaTrashAlt } from "react-icons/fa";

import { increaseQuantity, decreaseQuantity } from '../redux/reducers/cartReducer';
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook';
import { IAuthenticUser } from '../types/userType';
import ToggleButton from '../components/cart/ToggleButton';
import CartBtn from '../components/cart/CartBtn';
import CartTotal from '../components/cart/CartTotal';
import { NotFound } from '../styledComponent/productstyle';
import { ICartResponse } from "../types/cartType";

const Cart = () => {
  const cart:ICartResponse[] = useAppSelector(state => state.cartReducer)
  const dispatch = useAppDispatch();
  const authentication: IAuthenticUser = useAppSelector(state => state.auhtReducer)
  //let userCart = cart.filter((cartInfo: any) => { return cartInfo.userInfo.id === authentication.id })
  //const cartSize: number = userCart.length;
  const cartSize: number = cart.length;
  console.log('hihihh',cart)
  // let newuserCart = [new Set(cart.map((cartRow: any) => cartRow.products.ProductId))]
  // console.log(newuserCart.entries)
  function deleteCartitem(e: React.MouseEvent<SVGElement, MouseEvent>, id: number): void {
    e.preventDefault();
    //dispatch(removeFromCart(id))
  }
  const setIncrease = (id: number) => {
    dispatch(increaseQuantity(id))
  }
  const setDecrease = (id: number) => {
    dispatch(decreaseQuantity(id))
  }
  if (cartSize) {
   
    return (
      <>
        <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '60vh', height: 'auto', minWidth: '100vw', color: 'text.primary', backgroundColor: 'primary.main' }}>
          <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '10px', minWidth: '100vw', color: 'text.primary', marginTop: '20px' }}>
            <Grid container spacing={0} alignItems="center" justifyContent="center" sx={{ width: '900px', height: 'auto', minHeight: '100px', marginLeft: "20px", backgroundColor: 'primary.main', color: 'text.primary' }}>
              {/* <Grid item sx={{ fontSize: '10px', textAlign: 'center', backgroundColor: 'primary.main', color: 'text.primary' }}>
                {authentication.avatar ? `Shopping cart for user, ${authentication.name}` : `user has not logged in..`}
              </Grid> */}
            </Grid>
          </Grid>
          <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '5vh', minWidth: '100vw', color: 'text.primary', backgroundColor: 'primary.main' }}>
            <Grid container spacing={0} alignItems="center" justifyContent="center" sx={{ width: '1300px', height: 'auto', minHeight: '200px', marginLeft: "20px", backgroundColor: "primary.main", color: 'text.primary' }}>
              <Grid container spacing={0} direction="row" sx={{ padding: '10px', color: 'text.primary' }}>
                <Grid item xs={1}></Grid>
                <Grid item xs={3} sx={{ fontSize: '12px', color: 'text.primary' }}>Title</Grid>
                <Grid item xs={3} sx={{ fontSize: '12px', color: 'text.primary' }}>Quantity</Grid>
                <Grid item xs={2} sx={{ fontSize: '12px', color: 'text.primary' }}>Price</Grid>
                <Grid item xs={1} sx={{ fontSize: '12px', color: 'text.primary' }}>Subtotal</Grid>
                <Grid item xs={1} sx={{ fontSize: '12px', color: 'text.primary' }}>Remove</Grid>
                <Grid item xs={1}></Grid>
              </Grid>
              <Grid container>
                <Grid item sx={{ width: '1300px', border: '1px solid lightgray' }}></Grid>
              </Grid>
              {cart.map((cartElement: any) => {
                return (
                  <Grid container alignItems="center" justifyContent="center" spacing={0} direction="row">
                    <Grid item xs={1} ></Grid>
                    <Grid item xs={3} sx={{ fontSize: '10px' }}>
                      <Grid container alignItems="center" justifyContent="center" spacing={0} direction="row" >
                        <Grid item xs={4}><img src={cartElement.products.category.image} alt={cartElement.products.category.image} width='40px' height='40px' /></Grid>
                        <Grid item xs={8} sx={{ color: 'text.primary' }}>  {cartElement.products.title}</Grid>
                      </Grid>
                    </Grid>
                    <Grid item xs={3} sx={{ fontSize: '10px', color: 'text.primary' }}>
                      <ToggleButton amount={cartElement.quantity} setIncrease={() => { setIncrease(cartElement.products.id) }} setDecrease={() => setDecrease(cartElement.products.id)} />
                    </Grid>
                    <Grid item xs={2} sx={{ fontSize: '10px', color: 'text.primary' }}>{cartElement.products.price}</Grid>
                    <Grid item xs={1} sx={{ fontSize: '10px', color: 'text.primary' }}>{cartElement.products.price * cartElement.quantity}</Grid>
                    <Grid item xs={1} sx={{ fontSize: '12px', color: 'text.primary' }}><FaTrashAlt style={{ fill: 'text.main' }} onClick={(e) => deleteCartitem(e, cartElement.products.id)} /></Grid>
                    <Grid item xs={1} ></Grid>
                  </Grid>
                )
              })}
            </Grid>
          </Grid>
        </Grid>
        <CartBtn />
        <CartTotal />
      </>
    )
  } else {
    return (<>
      <NotFound sx={{backgroundColor:'primary.main',color:'text.secondary'}}>Ooops!!! Cart is empty</NotFound>
    </>)
  }
}

export default Cart

