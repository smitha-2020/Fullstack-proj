import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";

export const fetchSession = createAsyncThunk(
    "fetchSession",
    async (data: string) => {
        try {
            const response = await axios.get("https://api.escuelajs.co/api/v1/auth/profile", { headers: { Authorization: `Bearer ${data}` } })
            return response.data;
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)