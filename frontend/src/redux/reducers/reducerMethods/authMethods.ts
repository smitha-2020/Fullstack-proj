import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError, AxiosResponse } from "axios";
import { IAuthenticUser, IRegisteredUser, IUserResponse } from "../../../types/userType";

export const fetchSession = createAsyncThunk(
    "fetchSession",
    async (data: string) => {
        try {
            var inputData = {};
            var avatar;
            const response:AxiosResponse<any,IAuthenticUser> = await axios.post("https://localhost:5001/tokens",inputData, { headers: {'Authorization': `Bearer ${data}`} })
            var userId = response.data.sub;
            if(userId){
                const responseAvatar:AxiosResponse<any,IUserResponse> = await axios.get(`https://localhost:5001/users/${userId}`, { headers: {'Authorization': `Bearer ${data}`}})
                if(responseAvatar.data){
                    avatar = responseAvatar.data.avatar
                    //console.log("avatra",avatar) 
                }
            }
            return {...response.data,avatar:avatar}
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)