import { Box, Button, TextField, Typography } from '@mui/material'
import { useNavigate } from "react-router-dom";
import axios from 'axios';
import { useForm, SubmitHandler } from 'react-hook-form';

import {IProductBase } from '../../types/productType';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
//import { addingProduct } from '../../redux/reducers/reducerMethods/productMethods';


const CreateProduct = () => {
  const navigate = useNavigate();
  const { register, handleSubmit, reset, watch, formState: { errors } } = useForm<IProductBase>({
    defaultValues: {
      title: "",
      price: 0,
      description: "",
      categoryId: 0,
    }
  });
  const uploadImageData = async (data: IProductBase) => {
    const responseImg = await axios.post("https://api.escuelajs.co/api/v1/files/upload", { 'file': data.imagestr[0] }, { headers: { 'Content-Type': 'multipart/form-data' } })
    return responseImg.data;
  }
  const product = useAppSelector(state => state.productReducer)
  const dispatch = useAppDispatch();
  const onSubmit: SubmitHandler<IProductBase> = async (data) => {
    if (data.description) {
      const uploadedImage = await uploadImageData(data)

      const newDatanew = {title:data.title,price:data.price,description:data.description,categoryId:data.categoryId, images: [uploadedImage['location']] }
      //const newData = { ...data, images: [uploadedImage['location']] }
      //dispatch(addingProduct(newDatanew))
      if (product.isDone) {
        navigate('/fulfilled')
      }
    } else {
      reset({ title: "", price: 0, description: "", categoryId: 0 })
    }
  };
  const categories = useAppSelector(state => state.categoryReducers)
  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
          <Typography variant="h6" textAlign="center" padding={3}> Add Product</Typography>
          <TextField type="text" variant="outlined" placeholder="title" margin="normal" {...register("title")} />
          <TextField type="text" variant="outlined" placeholder="price" margin="normal" {...register("price")} />
          <TextField type="text" variant="outlined" placeholder="description" margin="normal"  {...register("description")} />
          <p><span>Category Source</span>
            <select {...register("categoryId")}>
              {
                categories.map((source) => <option key={source.id} value={source.id}>{source.name}</option>)
              }
            </select>
          </p>
          <input type="file" id="myFile" style={{ marginTop: "10px" }} {...register("imagestr")} />
          <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Add</Button>
          <br />
          {/* <p className="successMsg">{product.isDone ? 'Data Added successfully' : ''}</p> */}
        </Box>
      </form>
    </>
  )
}

export default CreateProduct