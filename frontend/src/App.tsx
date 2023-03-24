
import { useEffect, useMemo, useState } from 'react'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { createTheme, ThemeProvider } from '@mui/material'

import { useAppDispatch, useAppSelector } from './hooks/reduxHook'
import Login from './components/Login'
import Home from './Pages/Home'
import Products from './Pages/Products'
import Cart from './Pages/Cart'
import Profile from './Pages/Profile'
import Header from './components/Header'
import { fetchAllProducts } from './redux/reducers/reducerMethods/productMethods'
import { fetchAllCategories } from './redux/reducers/reducerMethods/categoryMethods'
import Register from './Pages/Register'
import { fetchSession } from './redux/reducers/reducerMethods/authMethods'
import Footer from './components/Footer'
import Fulfilled from './components/products_actions/Fulfilled'

const getDesignTokens = (mode: any) => ({
  palette: {
    mode,
    ...(mode === "light"
      ? {
        // palette values for light mode
        primary: {
          main: "#ffffff",
        },
        divider: "#fde68a",
        background: {
          default: "#fbbf24",
          paper: "",
        },
        text: {
          primary: "#a6a6a6",
          secondary: "#27272a",
        },
      }
      : {
        // palette values for dark mode
        primary: {
          main: "#000e21",
        },
        divider: "#fbbf24",
        background: {
          default: "#fbbf24",
          paper: "#fbbf24",
        },
        text: {
          primary: "#fbbf24",
          secondary: "#fbbf24",
        },
      }),
  },
});
const App = () => {
  const [mode, setMode] = useState("light");
  const darkMode = useAppSelector(state => state.switchReducer.darkMode)
  useMemo(() => {
    if (darkMode) {
      setMode("dark");
    } else {
      setMode("light");
    }
  }, [darkMode]);
  const theme = useMemo(() => createTheme(getDesignTokens(mode)), [mode]);
  const authentication = useAppSelector(state => state.loginReducer.user)
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchAllProducts())
    dispatch(fetchAllCategories())
    const userJson = localStorage.getItem('access_token')!;
    if (!userJson) {
      //console.log("Authentication Failed")
    } else {
      dispatch(fetchSession(userJson))
    }
  }, []);
  return (
    <>
      <div>
        <BrowserRouter>
          <Header />
          <ThemeProvider theme={theme}>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/products" element={<Products />} />
              <Route path="/product/:id" element={<Products />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/cart" element={<Cart />} />
              <Route path="profile" element={<Profile />} />
              <Route path="/fulfilled" element={<Fulfilled />} />
            </Routes>
          </ThemeProvider>
          <Footer />
        </BrowserRouter>
      </div>
    </>
  )
}

export default App