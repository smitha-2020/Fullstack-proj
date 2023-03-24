
import { createSlice } from '@reduxjs/toolkit'
import { IAuthenticUser } from '../../types/userType';
import { getAllUsers, getUser, createUser, updateUser } from '../../redux/reducers/reducerMethods/userMethods'

const initialState: IAuthenticUser[] = []

export const userSlice = createSlice({
    name: "userSlice",
    initialState,
    reducers: {},
    extraReducers: (build) => {
        build.addCase(getAllUsers.fulfilled, (state, action) => {
            if (action.payload && "message" in action.payload) {
                return state;
            } else {
                if (action.payload) {
                    return action.payload;
                }
            }
            return state;
        })
            .addCase(getAllUsers.pending, (state, action) => {
                return state;
            })
            .addCase(getAllUsers.rejected, (state, action) => {
                return state;
            })
            .addCase(getUser.fulfilled, (state, action) => {
                if (action.payload && "message" in action.payload) {
                    return state;
                } else {
                    if (action.payload) {
                        return action.payload;
                    }
                }
                return state;
            })
            .addCase(getUser.pending, (state, action) => {
                return state;
            })
            .addCase(getUser.rejected, (state, action) => {
                return state;
            })
            .addCase(createUser.fulfilled, (state, action) => {
                if (action.payload && "message" in action.payload) {
                    return state;
                } else {
                    if (action.payload) {
                        return [action.payload];
                    }
                }
                return state;
            })
            .addCase(createUser.pending, (state, action) => {
                return state;
            })
            .addCase(createUser.rejected, (state, action) => {
                return state;
            })
            .addCase(updateUser.fulfilled, (state, action) => {
                if (action.payload && "message" in action.payload) {
                    return state;
                } else {
                    const modifyState = [...state]
                    //console.log(modifyState.map(user => user.id === action.payload?.id ? action.payload : user))
                    return  modifyState.map(user => user.id === action.payload?.id ? action.payload : user)
                    //return [...result]
                }
                return state;
            })
            .addCase(updateUser.pending, (state, action) => {
                return state;
            })
            .addCase(updateUser.rejected, (state, action) => {
                return state;
            })
    }
})

const userReducer = userSlice.reducer;
export default userReducer;