import { configureStore, ThunkAction, Action, combineReducers } from '@reduxjs/toolkit';
import productReducer from './reducers/productReducers';
import loginReducer from './reducers/loginInfo'
import categoryReducers from './reducers/categoryReducers';
import cartReducer from './reducers/cartReducer';
import auhtReducer from './reducers/authReducer';
import switchReducer from './reducers/themeSwitcher';
import {
  persistStore,
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from 'redux-persist'

import storage from 'redux-persist/lib/storage'
import userReducer from './reducers/userReducers';

const persistConfig = {
  key: 'root',
  version: 1,
  storage,
  blacklist:['auhtReducer','loginReducer','productReducer']
}
const reducers = combineReducers(
  {
    cartReducer,
    auhtReducer,
    switchReducer,
    productReducer,
    loginReducer,
    categoryReducers,
    userReducer
  }
)
const persistedReducer = persistReducer(persistConfig, reducers)
export const createStore = () => {
  return configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }),
  });
}
const store = createStore();
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
