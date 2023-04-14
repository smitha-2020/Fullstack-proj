import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IProduct, IProductDetails } from "../../types/productType";
import {
  fetchAllProducts,
  // fetchAllProductsbyCategory,
  deletingProduct,
  // modifyProduct,
  addingProduct,
  modifyProduct,
  // getSingleProduct,
} from "./reducerMethods/productMethods";
import { FaBullseye } from "react-icons/fa";

const initialState: IProductDetails = {
  product: [],
  totalCount: 0,
  isDone: false,
  isLoading: false,
  isSuccess: false,
};
const productSlice = createSlice({
  name: "productSlice",
  initialState: initialState,
  reducers: {
    ascendingOrder: (state, action: PayloadAction<"asc" | "desc">) => {
      if (action.payload === "asc") {
        state.product.sort((a, b) => a.title.localeCompare(b.title));
      } else {
        state.product.sort((a, b) => b.title.localeCompare(a.title));
      }
    },
    sortByPrice: (state, action: PayloadAction<"hightolow" | "lowtohigh">) => {
      if (action.payload === "hightolow") {
        state.product.sort((a, b) => a.price - b.price);
      } else {
        state.product.sort((a, b) => b.price - a.price);
      }
    },
  },
  extraReducers: (build) => {
    build
      .addCase(
        fetchAllProducts.fulfilled,
        (state, action: PayloadAction<IProduct[]>) => {
          if (!action.payload) {
            return state;
          }
          return {
            ...state,
            product: action.payload,
            totalCount: action.payload.length,
            isSuccess: false,
          };
        }
      )
      .addCase(addingProduct.fulfilled, (state, action) => {
        console.log(action.payload)
        if (action.payload) {
          return {
            ...state,
            isSuccess: true,
            product: [...state.product, action.payload],
          };
        }
      })
      .addCase(deletingProduct.fulfilled, (state, action) => {
        if (action.payload) {
          const newReturn = state.product.filter((reqData) => {
            return reqData.id !== action.payload;
          });
          return { ...state, product: newReturn, isSuccess: true };
        }
      })
      .addCase(modifyProduct.fulfilled, (state, action) => {
        if (action.payload) {
          const newReturn = state.product.filter((reqData) => {
            return reqData.id !== action.payload.id;
          });
          return {
            ...state,
            isSuccess: true,
            product: [...newReturn, action.payload],
          };
        }
      })

    //     .addCase(addingProduct.fulfilled, (state, action) => {
    //       if (action.payload && "message" in action.payload) {
    //         state.isDone = true;
    //         state.isLoading = false;
    //         return state;
    //       }else{
    //         state.isDone = false;
    //         if (action.payload) {
    //           return {
    //             ...state,
    //             product: [...state.product,action.payload],
    //             isDone: true,
    //           };
    //         }else{
    //           state.isDone = true;
    //           state.isLoading = false;
    //         }
    //       }
    //       state.isDone = false;
    //       return state;
    //     })
    //     .addCase(addingProduct.rejected, (state) => {
    //       state.isDone = true;
    //       state.isLoading = false;
    //       return state
    //   })
    //     .addCase(addingProduct.pending, (state) => {
    //         state.isLoading = true;
    //         state.isDone = false;
    //         return state
    //     })
    //     // .addCase(modifyProduct.fulfilled, (state, action) => {
    //     //   if (action.payload) {
    //     //     const getProducts = [...state.product];
    //     //     const updateProducts = getProducts.map((product) =>
    //     //       product.id === action.payload?.id ? action.payload : product
    //     //     );
    //     //     return { ...state, product: updateProducts, isDone: true };
    //     //   }
    //     // })
    // .addCase(deletingProduct.fulfilled, (state, action) => {
    //   state.isDone=false;
    //   state.isLoading=true;
    //   var count = state.product.length;
    //   if (action.payload) {
    //     const newReturn = state.product.filter((reqData) => {
    //       return reqData.id !== action.payload;
    //     });
    //     if(count> newReturn.length){
    //       state.isDone=true;
    //     }
    //     return { ...state, product: newReturn};
    //   }else{
    //     state.isDone = true;
    //     state.isLoading = false;
    //   }
    //   return state;
    // })
    // .addCase(deletingProduct.rejected, (state) => {
    //   state.isDone = true;
    //   state.isLoading = false;
    //   return state
    //   })
    // .addCase(deletingProduct.pending, (state) => {
    //     state.isLoading = true;
    //     state.isDone = false;
    //     return state
    // })
  },
});

const experimentReducer = productSlice.reducer;
export default experimentReducer;
export const { ascendingOrder, sortByPrice } = productSlice.actions;
