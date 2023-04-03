import { Box, Button, TextField, Typography } from '@mui/material'
import { IProduct, IProductModify, IProductOpt } from '../../types/productType';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { useForm, SubmitHandler } from 'react-hook-form';

//import { json } from 'stream/consumers';
//import { string } from 'yup';
import { modifyProduct } from '../../redux/reducers/reducerMethods/productMethods';
import { ChangeEvent, useState } from 'react';
import { useNavigate } from "react-router-dom";

const UpdateProduct = () => {
  const { register, handleSubmit, reset, watch,setValue, formState: { errors } } = useForm<IProductOpt>({});
  const navigate = useNavigate();
  const [isloading,setIsLoading] = useState(false);
  const [image,setImage] =useState<string[]>([]);
  const product = useAppSelector(state => state.productReducer)
  const categories = useAppSelector(state => state.categoryReducers)
  const dispatch = useAppDispatch();
  let selectedItem:IProduct[] = [];
  const onSubmit: SubmitHandler<IProductOpt> = async(data) => {
    if (data.id) {
      const { id, categoryId, ...dataRemaing } = data
      const newData: IProductModify = { id: id, updateProduct: dataRemaing,images:image }
      console.log(newData.images.length)
      await dispatch(modifyProduct(newData))
      // if (product.isDone) {
      //   navigate('/fulfilled')
      // }
    }
  };

  const uploadImage = async(e: any) => {
    const files = e.target.files[0];
    console.log(files.name);
    const data = new FormData();
    data.append('file',files);
    data.append('upload_preset','geekyimages');
    const response = await fetch('https://api.cloudinary.com/v1_1/dllghhg4r/auto/upload',{
      method:'POST',
      mode:'cors',
      body:data
    })
    const file =await response.json();
    setImage([...image,file.secure_url]);
  }

  const productIdSelected = (e: ChangeEvent<HTMLSelectElement>) => {
    selectedItem = product.product.filter((productItem) => { return productItem.id === Number(e.target.value) })
    setValue('id',selectedItem[0].id)
    setValue('title',selectedItem[0].title)
    setValue('price',selectedItem[0].price)
    setValue('description',selectedItem[0].description)
    setValue('categoryId',selectedItem[0].category.id)
    //setValue('data.title',selectedItem[0].title)
  }
  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
          <Typography variant="h6" textAlign="center" padding={3}> Update Product</Typography>
          <p><span>Category Source</span>
            <select {...register("id")} onChange={productIdSelected}>
              <option>---select product----</option>
              {
                product.product.map((productData) => <option key={productData.id} value={productData.id}>{productData.title}</option>)
              }
            </select>
          </p>
          <TextField type="text" variant="outlined" placeholder="title" margin="normal" {...register("title")} />
          <TextField type="text" variant="outlined" placeholder="price" margin="normal" {...register("price")} />
          <TextField type="text" variant="outlined" placeholder="description" margin="normal"  {...register("description")} />
          <p><span>Category Source</span>
            <select {...register("categoryId")}>
              <option>---select product----</option>
              {
                categories.map((source) => <option key={source.id} value={source.id}>{source.name}</option>)
              }
            </select>
          </p>
          {/* <input type="file" id="myFile" style={{ marginTop: "10px" }} {...register("images")} /> */}
          <input type="file" id="myfile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
          <input type="file" id="myFile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
          <input type="file" id="myFile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>

           {/* <p className="successMsg">{isloading ? 'Image Loading...' : ''}</p> */}
          <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Update</Button>
          <br />
          {/* <p className="successMsg">{product.isDone && 'Data Updated'}</p> */}
          <p className="successMsg">Fill the fields you wish to update.Select the Product Id</p>
        </Box>
      </form>
    </>
  )
}

export default UpdateProduct