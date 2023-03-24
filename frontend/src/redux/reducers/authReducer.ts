
import { createSlice } from '@reduxjs/toolkit'
import { IAuthenticUser } from '../../types/userType'
import { fetchSession } from './reducerMethods/authMethods';

const initialState: IAuthenticUser = { id: 0, avatar: "", email: "", password: "", name: "", role: "" };
//get the user session

export const authSlice = createSlice({
    name: "authSlice",
    initialState: initialState,
    reducers: {
        clearSession(state) {
            return { id: 0, avatar: "", email: "", password: "", name: "", role: "" }
        }
    },
    extraReducers: (build) => {
        build.addCase(fetchSession.fulfilled, (state, action) => {
            return action.payload;
        })
        .addCase(fetchSession.rejected, (state) => {
            return state
        })
        .addCase(fetchSession.pending, (state) => {
            return state
        })
    }
})

const auhtReducer = authSlice.reducer;
export default auhtReducer;
export const { clearSession } = authSlice.actions;