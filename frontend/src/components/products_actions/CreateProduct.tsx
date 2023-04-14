import { Box, Button, TextField, Typography } from '@mui/material'
import { useNavigate } from "react-router-dom";
import { useForm, SubmitHandler } from 'react-hook-form';
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"

import {IProductBase } from '../../types/productType';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { addingProduct } from '../../redux/reducers/reducerMethods/productMethods';
import { useEffect, useState } from 'react';

const schema = yup.object().shape({

})
const CreateProduct = () => {
  const [isloading,setIsLoading] = useState(false);
  const [image,setImage] =useState<string[]>([]);
  const [isFile,setIsFile] =useState<boolean>(false);
  const [isAdded,setIsAdded] =useState<boolean>(false);
  const [showMessage,setShowMessage] =useState<string>("");
  const product = useAppSelector(state => state.productReducer)
  const data = useAppSelector(state => state.auhtReducer)
  useEffect(() => { 
   
  }, [product.isSuccess])
  const navigate = useNavigate();
  const { register, handleSubmit, reset, watch, formState: { errors } } = useForm<IProductBase>({
    defaultValues: {
      title: "",
      price: 0,
      description: "",
      categoryId: 0
    }
  });
    const uploadImage = async(e: any) => {
    setIsLoading(true);
    const files = e.target.files[0];
    //console.log(files.name);
    const data = new FormData();
    data.append('file',files);
    data.append('upload_preset','geekyimages');
    const response = await fetch('https://api.cloudinary.com/v1_1/dllghhg4r/auto/upload',{
      method:'POST',
      mode:'cors',
      body:data
    })
    const file =await response.json();
    console.log(file);
    setImage([...image,file.secure_url]);
    setIsLoading(false);
  }
  const dispatch = useAppDispatch();
  const onSubmit: SubmitHandler<IProductBase> = async (data) => {
    if (data.description) {
      const newDatanew = {title:data.title,price:data.price,description:data.description,categoryId:data.categoryId }
      if(image.length<3){
        setIsFile(true);
      }else{
        setIsFile(false);
      }
      const newData = { ...newDatanew, imagestr: image }
      await dispatch(addingProduct(newData))
      reset({ title: "", price: 0, description: "", categoryId: 0 })
      setShowMessage("Added Successfully");
      setTimeout(()=> setShowMessage(""),5000 )
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
          <TextField  id="title" type="text" variant="outlined" placeholder="title" margin="normal" {...register("title",{ required: true, min: 1, max: 100 })} />
          {errors.title && errors.title.type === "required" && <span className="errorwarnings">This is required</span>}
          <TextField type="text" variant="outlined" placeholder="price" margin="normal" {...register("price",{ required: true, min: 1, max: 10000 })}/>
          {errors.price && errors.price.type === "required" && <span className="errorwarnings">This is required</span>}
          {errors.price && errors.price.type === "max" && <span className="errorwarnings">Price Cannot Exceed 10000 </span>}
          {errors.price && errors.price.type === "min" && <span className="errorwarnings">Price Cannot Be Less than 1</span>}
          <TextField type="text" variant="outlined" placeholder="description" margin="normal"  {...register("description",{ required: true})} />
          {errors.description && errors.description.type === "required" && <span className="errorwarnings">This is required</span>}
          <p><span>Category Source</span>
            <select {...register("categoryId",{required:true})}>
              {
                categories.map((source) => <option key={source.id} value={source.id}>{source.name}</option>)
              }
            </select>
          </p>
           {errors.description && errors.description.type === "required" && <span className="errorwarnings">This is required</span>}
           <input type="file" id="myfile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
           <input type="file" id="myFile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
           <input type="file" id="myFile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
           <p className="successMsg">{isloading ? 'Image Loading...' : ''}</p>
           <p className="errorwarnings">{isFile ? 'Please load all the images(3)' : ''}</p>

           <p className="successMsg">{showMessage}</p>
          <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Add</Button>
          <br />
        </Box>
      </form>
    </>
  )
}

export default CreateProduct