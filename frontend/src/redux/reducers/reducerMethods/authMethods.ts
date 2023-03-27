import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";

export const fetchSession = createAsyncThunk(
    "fetchSession",
    async (data: string) => {
        try {
            const response = await axios.post("https://localhost:5001/tokens", { headers: {'Authorization': `Bearer ${data}`} })
            console.log("qweqweqweqwewqeqweqweqweqweqweqweqwe", data)
            return response.data;
        } catch (e) {
            const error = e as AxiosError
            console.log('Errorrrrrrrrrrrrr',error)
            return error
        }
    }
)