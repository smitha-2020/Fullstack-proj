import { createSlice } from '@reduxjs/toolkit'
import { AxiosError } from 'axios';
import { ICategory } from '../../types/productType';
import { fetchAllCategories,createCategory,deleteCategory } from './reducerMethods/categoryMethods';

// getSingleCategory, , updateCategory,

const initialState: ICategory[] = [];

const categorySlice = createSlice({
    name: "categorySlice",
    initialState: initialState,
    reducers: {
    },
    extraReducers: (build) => {
        build.addCase(fetchAllCategories.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state;
            }
            return action.payload
        })
            // .addCase(getSingleCategory.fulfilled, (state, action) => {
            //     if (action.payload instanceof AxiosError) {
            //         return state;
            //     } else {
            //         if (action.payload && "image" in action.payload) {
            //             return action.payload;
            //         } else {
            //             return state;
            //         }
            //     }
            // })
            .addCase(createCategory.fulfilled, (state, action) => {
                if (action.payload instanceof AxiosError) {
                    return state;
                } else {
                    if (action.payload && "name" in action.payload) {
                        return [...state, action.payload]
                    } else {
                        return state;
                    }
                }
            })
            // .addCase(updateCategory.fulfilled, (state, action) => {
            //     if (action.payload instanceof AxiosError) {
            //         return state;
            //     } else {
            //         const returnedData = action.payload;
            //         return state.map(category => {
            //             return category.id === returnedData.id ? returnedData : category
            //         }
            //         )
            //     }
            // })
            .addCase(deleteCategory.fulfilled, (state, action) => {
                const data = [...state]
                const result = data.filter(category => { return category.id === action.payload })
                return result
            })
    }
})

const categoryReducers = categorySlice.reducer;

export default categoryReducers;

