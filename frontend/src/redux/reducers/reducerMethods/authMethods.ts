import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";

export const fetchSession = createAsyncThunk(
    "fetchSession",
    async (data: string) => {
        try {
            var inputData = {};
            const response = await axios.post("https://localhost:5001/tokens",inputData, { headers: {'Authorization': `Bearer ${data}`} })
            return response.data;
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)