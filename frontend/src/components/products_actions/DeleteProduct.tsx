import { useEffect } from 'react'
import { Box, Button, Typography } from '@mui/material'
import { useNavigate } from "react-router-dom";

import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { useForm, SubmitHandler } from 'react-hook-form';
import { IProductOpt } from '../../types/productType';
import { deletingProduct, fetchAllProducts } from '../../redux/reducers/reducerMethods/productMethods';

const DeleteProduct = () => {
  const { register, handleSubmit, reset, watch, setValue, formState: { errors } } = useForm<IProductOpt>({});
  const navigate = useNavigate();
  const product = useAppSelector(state => state.productReducer)
  useEffect(() => { 
    dispatch(fetchAllProducts())
  }, [product.isSuccess])
  const dispatch = useAppDispatch()
  const onSubmit: SubmitHandler<IProductOpt> = async (data) => {
    //console.log(data.id)
    const id = data.id;
    await dispatch(deletingProduct(id))
    navigate('/products');
    // if(product.isDone){
    //   navigate('/products')
    // }
   
  }
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
        <Typography variant="h6" textAlign="center" padding={3}> Delete Product</Typography>
        <p><span>Delete Product</span>
          <select {...register("id")} >
            <option>---select product----</option>
            {
              product.product.map((productData) => <option key={productData.id} value={productData.id}>{productData.title}</option>)
            }
          </select>
        </p>
        <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Delete</Button>
       
        <p className="successMsg">{product.isSuccess && 'Deleted...'}</p>
      </Box>
    </form>
  )
}

export default DeleteProduct