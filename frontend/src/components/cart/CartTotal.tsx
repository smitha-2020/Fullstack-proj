import { Grid } from "@mui/material";
import { useAppSelector } from '../../hooks/reduxHook';
import Typography from '@mui/material/Typography';

const CartTotal = () => {
    const cart = useAppSelector(state => { return state.cartReducer; })
    const carttotal = cart.reduce((acc, cartElement) => { return acc + (cartElement.product.price * cartElement.quantity) }, 0)
    return (
        <>
            <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '10px', minWidth: '100vw',backgroundColor:'primary.main' }}>
                <Grid container spacing={0} alignItems="center" justifyContent="center" sx={{ width: '1300px', height: 'auto', minHeight: '100px', marginLeft: "20px", }}>
                    <Grid item xs={8} sx={{ fontSize: '10px', textAlign: 'center' }}>
                    </Grid>
                    <Grid item xs={4} display="flex" flexDirection="column" sx={{ fontSize: '14px', textAlign: 'center', width: '40px', minHeight: '40px',height:'auto', backgroundColor: 'primary.main',color:'text.primary' }}>
                        <Grid container sx={{ padding: '10px' }}  >
                            <Grid item xs={12} display="flex" flexDirection="row" alignItems="center" justifyContent="center"  sx={{ padding: '10px' }}  >
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}>SubTotal:</Typography>
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}> ${carttotal}</Typography>
                            </Grid>
                            <Grid item xs={12} display="flex" flexDirection="row" alignItems="center" justifyContent="center"  sx={{ padding: '10px' }}  >
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}>Shipping:</Typography>
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}> $60</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <Grid item sx={{  border: '1px solid lightgray' }}></Grid>
                            </Grid>
                            <Grid item xs={12} display="flex" flexDirection="row" alignItems="center" justifyContent="center"  sx={{ padding: '10px',backgroundColor: 'primary.main',color:'text.primary' }}  >
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}>Total:</Typography>
                                <Typography sx={{ fontSize: '12px', fontWeight: 'bold',color:'text.primary' }}>${carttotal+Number(60)} </Typography>
                            </Grid>
                        </Grid>
                    </Grid>
                </Grid>
            </Grid>
        </>
    )
}

export default CartTotal