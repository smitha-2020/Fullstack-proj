import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { IAuthenticUser, ILoginData, Inputs } from "../../../types/userType";

//login
export const fetchLoginInfo = createAsyncThunk(
  "fetchLoginInfo",
  async (data: ILoginData) => {
    try {
      const response = await axios.post("https://localhost:5001/signin", data, {
        headers: { "Content-Type": "application/json" },
      });
      return response.data;
    } catch (e: any) {
      const error = e as AxiosError;
      return error;
    }
  }
);
//Registration
export const uploadImagefromForm = createAsyncThunk(
  "uploadImagefromForm",
  async (inputFile: Inputs) => {
    try {
      const responseRegister = await axios.post(
        "https://localhost:5001/signup",
        inputFile
      );
      return responseRegister.data;
    } catch (e: any) {
      const error = e as AxiosError;
      return error;
    }
  }
);
