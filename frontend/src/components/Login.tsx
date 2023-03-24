import { useForm, SubmitHandler } from 'react-hook-form';
import { NavLink, useNavigate } from 'react-router-dom'
import { Box, Button, Grid, Typography } from "@mui/material";
import TextField from '@mui/material/TextField';
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import LoginIcon from '@mui/icons-material/Login';

import { fetchLoginInfo } from '../redux/reducers/reducerMethods/loginMethods';
import { ILoginData } from '../types/userType';
import { fetchSession } from '../redux/reducers/reducerMethods/authMethods';
import { useAppSelector, useAppDispatch } from '../hooks/reduxHook'

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(6).required(),
})
const Login = () => {
  const navigate = useNavigate()
  const { isLogin, isLoading } = useAppSelector(state => state.loginReducer)
  const dispatch = useAppDispatch();
  const { register, handleSubmit, watch, formState: { errors } } = useForm<ILoginData>({
    resolver: yupResolver(schema)
  });
  const onSubmit: SubmitHandler<ILoginData> = async (data) => {
    try {
      await dispatch(fetchLoginInfo(data))
      const userJson = localStorage.getItem('access_token');
      if (userJson) {
        await dispatch(fetchSession(userJson))
        navigate('/profile')
      }
    }
    catch (e) {
      console.log(e)
    }
  };
  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '84vh', height: 'auto', minWidth: '100vw', color: 'lightgray', marginTop: '5px',backgroundColor:'primary.main' }}>
          <Box display="flex" flexDirection="column" maxWidth={400} alignItems="center" justifyContent="center" margin="auto" marginTop={5} padding={3} borderRadius={5} boxShadow={'5px 5px 10px lightgray'} sx={{ ":hover": { boxShadow: "10px 10px 10px lightgray", }, }}>
            <Typography variant="h2" textAlign="center" padding={3}>Login</Typography>
            <TextField type="email" variant="outlined" placeholder="Email" margin="normal"  {...register("email")} />
            <span className="errorwarnings">{errors.email?.message}</span>
            <TextField type="password" variant="outlined" placeholder="Password" margin="normal"  {...register("password")} />
            <span className="errorwarnings">{errors.password?.message}</span>
            <Button sx={{ marginTop: 3, borderRadius: 3, fill: 'white' }} variant="contained" color="warning" type="submit">Login<LoginIcon /></Button>
            <br />
            <span className="errorwarnings">{isLogin && "Login Failed.Try again"}</span>
            <span className="errorwarnings">{isLoading && "Loading..."}</span>
            <Button sx={{ marginTop: 3, borderRadius: 3, fontSize: 10 }}><NavLink to="/register">Not Registered yet?click to register..</NavLink></Button>
          </Box>
        </Grid>
      </form>
    </>
  )
}
export default Login


