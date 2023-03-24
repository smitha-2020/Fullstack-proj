import { Box, Button, Grid, TextField, Typography } from '@mui/material';
import { useForm, SubmitHandler } from 'react-hook-form';
import { AiOutlineLogin } from 'react-icons/ai';
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import { useNavigate } from 'react-router-dom';

import { useAppDispatch, useAppSelector } from '../hooks/reduxHook';
import { uploadImagefromForm } from '../redux/reducers/reducerMethods/loginMethods';
import { Inputs } from '../types/userType'

const schema = yup.object().shape({
    name: yup.string().min(6).required(),
    email: yup.string().email().required(),
    password: yup.string().min(6).required(),
    repassword: yup.string().oneOf([yup.ref("password"), null]),
    avatar: yup.mixed().required().test({
        test: (value) => value.length > 0,
        message: "Image field cannot be empty!!"
    })
})
const Register = () => {
    const navigate = useNavigate();
    const login = useAppSelector(state => state.loginReducer)
    const dispatch = useAppDispatch();
    const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>({
        resolver: yupResolver(schema)
    });
    const onSubmit: SubmitHandler<Inputs> = async(data) => {
        if (data.avatar) {
            await dispatch(uploadImagefromForm(data))
            navigate('/login') 
        }
    };
    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
                <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '84vh', height: 'auto', minWidth: '100vw', color: 'lightgray', marginTop: '5px',backgroundColor:'primary.main' }}>
                    <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
                        <Typography variant="h2" textAlign="center" padding={3}> SignUp</Typography>
                        <TextField type="text" variant="outlined" placeholder="Name" margin="normal" {...register("name")} />
                        <span className="errorwarnings">{errors.name?.message}</span>
                        <TextField type="email" variant="outlined" placeholder="Email" margin="normal" {...register("email")} />
                        <span className="errorwarnings"> {errors.email?.message}</span>
                        <TextField type="password" variant="outlined" placeholder="Password" margin="normal"  {...register("password")} />
                        <span className="errorwarnings"> {errors.password?.message}</span>
                        <TextField type="password" variant="outlined" placeholder="Re-Enter-Password" margin="normal" {...register("repassword")} />
                        <span className="errorwarnings"> {errors.repassword && 'passwords dont match'}</span>
                        <input type="file" id="myFile" style={{ marginTop: "10px" }} {...register("avatar")} />
                        <span className="errorwarnings"> {errors.avatar?.message}</span>
                        <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit"> Signup<AiOutlineLogin /></Button>
                        <br />
                        <span className="successMsg"> {login.isRegistered && "Successfully Registered!!!"}</span>
                    </Box>
                </Grid>
            </form>
        </>
    )
}

export default Register