import { createSlice } from '@reduxjs/toolkit'
import { ImodeCheck } from '../../types/common'

const initialState:ImodeCheck = {
    darkMode:false
}
export const switchSlice = createSlice({
    name:"switchSlice",
    initialState:initialState,
    reducers:{
        toggleTheme:(state) => {
            state.darkMode = !state.darkMode;
            console.log(state.darkMode)
        }
    }
})

const switchReducer = switchSlice.reducer;
export default switchReducer;
export const { toggleTheme } = switchSlice.actions;