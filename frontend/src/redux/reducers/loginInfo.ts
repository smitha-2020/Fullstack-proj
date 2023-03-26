import axios from 'axios'
import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import { ILoginData } from '../../types/userType';
import { Inputs, IAuthenticUser, IRegisteredUser } from '../../types/userType';
import {fetchLoginInfo, uploadImagefromForm} from '../reducers/reducerMethods/loginMethods';
import { fetchSession } from './reducerMethods/authMethods';

const initialState: IRegisteredUser =
{
    accessToken: "",
    user: {
        id: 0,
        avatar: "",
        email: "",
        name: "",
        role: ""
    },
    isRegistered: false,
    isLogin: false,
    isLoading: false
}
const loginSlice = createSlice({
    name: "LoginSlice",
    initialState: initialState,
    reducers: {
        setData: (state, action) => {
            localStorage.setItem("accessToken", state.accessToken)
            return state;
        },
        clearSession(state) {
            return {
                accessToken: "",
                user: {
                    id: 0,
                    avatar: "",
                    email: "",
                    password: "",
                    name: "",
                    role: ""
                },
                isRegistered: false,
                isLogin: false,
                isLoading: false
            }
        }
    },
    extraReducers: (build) => {
        build.addCase(fetchLoginInfo.fulfilled, (state, action) => {
            if (action.payload && "message" in action.payload) {
                state.isLogin = true;
                state.isLoading = false;
            } else {
                state.isLogin = false;
                if (action.payload && 'accessToken' in action.payload) {
                    localStorage.setItem('accessToken', action.payload.accessToken)
                    return action.payload;
                } else {
                    state.isLogin = true;
                    state.isLoading = false;
                }
            }
            return state;
        })
            .addCase(fetchLoginInfo.rejected, (state) => {
                state.isLogin = true;
                state.isLoading = false;
                return state
            })
            .addCase(fetchLoginInfo.pending, (state) => {
                state.isLoading = true;
                state.isLogin = false;
                return state
            })
            .addCase(uploadImagefromForm.fulfilled, (state, action) => {
                state.user = action.payload;
                if (action.payload) {
                    state.isRegistered = true;
                }
            })
            .addCase(uploadImagefromForm.rejected, (state, action) => {
                return state;
            })
            .addCase(uploadImagefromForm.pending, (state, action) => {
                return state;
            })

        // build.addCase(fetchSession.fulfilled, (state, action) => {
        //     console.log("user Data" + action.payload)
        //     state.user = action.payload;
        //     return action.payload.user;
        //     // if (action.payload && "message" in action.payload) {
        //     //     state.isLogin = true;
        //     //     state.isLoading = false;
        //     // } else {
        //     //     if (action.payload && 'avatar' in action.payload) {
        //     //         return action.payload.user;
        //     //     }else{
        //     //         state.isLogin = true;
        //     //         state.isLoading = false;
        //     //     }
        //     // }
        // })
        //     .addCase(fetchSession.rejected, (state) => {
        //         // state.isLogin = true;
        //         // state.isLoading = false;
        //         return state
        //     })
        //     .addCase(fetchSession.pending, (state) => {
        //         // state.isLogin = false;
        //         // state.isLoading = true;
        //         return state
        //     })
    }
});

const loginReducer = loginSlice.reducer;
export default loginReducer;

export const { setData } = loginSlice.actions;
