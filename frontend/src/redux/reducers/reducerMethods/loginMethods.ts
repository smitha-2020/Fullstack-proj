import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { IAuthenticUser, ILoginData, Inputs } from "../../../types/userType";

//login
export const fetchLoginInfo = createAsyncThunk(
    "fetchLoginInfo",
    async (data: ILoginData) => {
        try {
            const response = await axios.post("https://localhost:5001/signin", data, { headers: { 'Content-Type': 'application/json' } })
            return response.data;
        } catch (e: any) {
            const error = e as AxiosError
            return error
        }
    }
)
//Registration
export const uploadImagefromForm = createAsyncThunk(
    "uploadImagefromForm",
    async (inputFile: Inputs) => {
        try {
                const response = await axios.post("https://api.escuelajs.co/api/v1/files/upload", { 'file': inputFile.avatar[0] }, { headers: { 'Content-Type': 'multipart/form-data' } })
                const url: string = response.data.location;
                if (url) {
                    const responseRegister = await axios.post("https://localhost:5001/signup", { ...inputFile, avatar: url })
                    return responseRegister.data
                }
        } catch (e: any) {
            const error = e as AxiosError
            return error
        }
    }
)
