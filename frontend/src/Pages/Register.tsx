import { Box, Button, Grid, TextField, Typography } from '@mui/material';
import { useForm, SubmitHandler } from 'react-hook-form';
import { AiOutlineLogin } from 'react-icons/ai';
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import { useNavigate } from 'react-router-dom';

import { useAppDispatch, useAppSelector } from '../hooks/reduxHook';
import { uploadImagefromForm } from '../redux/reducers/reducerMethods/loginMethods';
import { Inputs } from '../types/userType'
import { useState } from 'react';

const schema = yup.object().shape({
    username: yup.string().min(6).required(),
    firstname: yup.string().min(3).required(),
    lastname: yup.string().min(3).required(),
    email: yup.string().email().required(),
    password: yup.string().min(6).required(),
    confirmpassword: yup.string().oneOf([yup.ref("password"), null])
    // avatar: yup.mixed().required().test({
    //     test: (value) => value.length > 0,
    //     message: "Image field cannot be empty!!"
    // })
})
const Register = () => {
    const [isloading,setIsLoading] = useState(false);
    const [isFile,setIsFile] =useState<boolean>(false);
    const [image,setImage] =useState<string>("");
    const navigate = useNavigate();
    const login = useAppSelector(state => state.loginReducer)
    const dispatch = useAppDispatch();
    const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>({
        resolver: yupResolver(schema)
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
    const onSubmit: SubmitHandler<Inputs> = async(data) => {
        const newData = {...data,avatar:image};
        if(image !== ""){
            setIsFile(false);
            console.log("newData",newData)
            await dispatch(uploadImagefromForm(newData))
            navigate('/login') 
        }else{
            setIsFile(true);
        }
    };
    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
                <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '84vh', height: 'auto', minWidth: '100vw', color: 'lightgray', marginTop: '5px',backgroundColor:'primary.main' }}>
                    <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
                        <Typography variant="h2" textAlign="center" padding={3}> SignUp</Typography>
                        <TextField type="text" variant="outlined" placeholder="FirstName" margin="normal" {...register("firstname")} />
                        <span className="errorwarnings">{errors.firstname?.message}</span>
                        <TextField type="text" variant="outlined" placeholder="LastName" margin="normal" {...register("lastname")} />
                        <span className="errorwarnings">{errors.lastname?.message}</span>
                        <TextField type="text" variant="outlined" placeholder="UserName" margin="normal" {...register("username")} />
                        <span className="errorwarnings">{errors.username?.message}</span>
                        <TextField type="email" variant="outlined" placeholder="Email" margin="normal" {...register("email")} />
                        <span className="errorwarnings"> {errors.email?.message}</span>
                        <TextField type="password" variant="outlined" placeholder="Password" margin="normal"  {...register("password")} />
                        <span className="errorwarnings"> {errors.password?.message}</span>
                        <TextField type="password" variant="outlined" placeholder="Re-Enter-Password" margin="normal" {...register("confirmpassword")} />
                        <span className="errorwarnings"> {errors.confirmpassword && 'passwords dont match'}</span>
                        <input type="file" id="myFile" style={{ marginTop: "10px" }} placeholder="uploadImage" onChange={uploadImage}/>
                        <p className="successMsg">{isloading ? 'Image Loading...' : ''}</p>
                        {/* <input type="file" id="myFile" style={{ marginTop: "10px" }} {...register("avatar")} /> */}
                        <span className="errorwarnings"> {errors.avatar?.message}</span>
                        <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Signup<AiOutlineLogin /></Button>
                        <br />
                         <p className="errorwarnings">{isFile ? 'Please load the avatar' : ''}</p>
                        <span className="successMsg"> {login.isRegistered && "Successfully Registered!!!"}</span>
                    </Box>
                </Grid>
            </form>
        </>
    )
}

export default Register