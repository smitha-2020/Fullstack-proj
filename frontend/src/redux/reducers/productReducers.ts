import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IProduct, IProductDetails } from "../../types/productType";
import {
  fetchAllProducts,
  // fetchAllProductsbyCategory,
  // deletingProduct,
  // modifyProduct,
  // addingProduct,
  // getSingleProduct,
} from "./reducerMethods/productMethods";

const initialState: IProductDetails = {
  product: [],
  totalCount: 0,
  isDone: false,
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
          console.log(action.payload)
          state.product = action.payload;
          state.totalCount = action.payload.length;
        }
      )
      // .addCase(
      //   fetchAllProductsbyCategory.fulfilled,
      //   (state, action: PayloadAction<IProduct[] | Error>) => {
      //     if (action.payload && "message" in action.payload) {
      //       return state;
      //     } else {
      //       if (action.payload) {
      //         const getCategory = action.payload;
      //         console.log({ ...state, product: getCategory });
      //       }
      //     }
      //   }
      // )
      // .addCase(getSingleProduct.fulfilled, (state, action) => {
      //   if (action.payload && "message" in action.payload) {
      //     return state;
      //   }
      //   return { ...state, product: action.payload };
      // })
      // .addCase(addingProduct.fulfilled, (state, action) => {
      //   if (action.payload && "message" in action.payload) {
      //     return state;
      //   }
      //   if (action.payload) {
      //     return {
      //       ...state,
      //       product: [...state.product,action.payload],
      //       isDone: true,
      //     };
      //   }
      // })
      // .addCase(modifyProduct.fulfilled, (state, action) => {
      //   if (action.payload) {
      //     const getProducts = [...state.product];
      //     const updateProducts = getProducts.map((product) =>
      //       product.id === action.payload?.id ? action.payload : product
      //     );
      //     return { ...state, product: updateProducts, isDone: true };
      //   }
      // })
      // .addCase(deletingProduct.fulfilled, (state, action) => {
      //   if (action.payload) {
      //     const newReturn = state.product.filter((reqData) => {
      //       return reqData.id !== action.payload;
      //     });
      //     return { ...state, product: newReturn, isDone: true };
      //   }
      // })
  },
});

const experimentReducer = productSlice.reducer;
export default experimentReducer;
export const { ascendingOrder, sortByPrice } = productSlice.actions;
