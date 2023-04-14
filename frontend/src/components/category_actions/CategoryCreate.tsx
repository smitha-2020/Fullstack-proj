import { Box, Button, TextField, Typography } from '@mui/material'
import { useForm, SubmitHandler } from 'react-hook-form';
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import React, { useState } from 'react'
import { ICategoryBase } from '../../types/productType';
import { useAppDispatch } from '../../hooks/reduxHook';
import { createCategory } from '../../redux/reducers/reducerMethods/categoryMethods';

const schema = yup.object().shape({
  name: yup.string().required(),
})

const CategoryCreate = () => {
    const [isloading,setIsLoading] = useState(false);
    const [image,setImage] =useState<string>("");
    const [showMessage,setShowMessage] =useState<string>("");
    const [isFile,setIsFile] =useState<boolean>(false);
    const { register, handleSubmit, reset, watch, formState: { errors } } = useForm<ICategoryBase>({
      defaultValues: {
        name: "",
        image: ""
      }
    });
    const uploadImage = async(e: any) => {
        setIsLoading(true);
        const files = e.target.files[0];
        const data = new FormData();
        data.append('file',files);
        data.append('upload_preset','geekyimages');
        const response = await fetch('https://api.cloudinary.com/v1_1/dllghhg4r/auto/upload',{
          method:'POST',
          mode:'cors',
          body:data
        })
        const file =await response.json();
        setImage(file.secure_url);
        setIsLoading(false);
      }
      const dispatch = useAppDispatch();
      const onSubmit: SubmitHandler<ICategoryBase> = async (data) => {
        if(image !== ""){
          setIsFile(false);
          const newData = { ...data, image: image }
          await dispatch(createCategory(newData))
          reset({ name:"",image:"" })
          setShowMessage("Created Successfully");
          setTimeout(()=> setShowMessage(""),5000 )
        }else{
          //console.log("image",image)
          setIsFile(true);
        }
      };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
    <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
      <Typography variant="h6" textAlign="center" padding={3}> Add Category</Typography>
      <TextField  id="title" type="text" variant="outlined" placeholder="title" margin="normal" {...register("name",{ required: true, min: 1, max: 100 })} />
      {errors.name && errors.name.type === "required" && <span className="errorwarnings">This is required</span>}
       <input type="file" id="myfile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
       <p className="successMsg">{isloading ? 'Image Loading...' : ''}</p>
       <p className="errorwarnings">{isFile ? 'Please load the image' : ''}</p>
       <p className="successMsg">{showMessage}</p>
      <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Add</Button>
      <br />
    </Box>
  </form>
  )
}

export default CategoryCreate