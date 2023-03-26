import React, { useState } from 'react'
import { RootState } from '../redux/store';
import { useParams } from 'react-router-dom';
import { Box, FormControl, SelectChangeEvent, Grid, Pagination } from '@mui/material';

import Category from '../components/category/Category'
import ProductList from '../components/product/ProductList';
import { useAppSelector, useAppDispatch } from '../hooks/reduxHook'
import { ascendingOrder, sortByPrice } from '../redux/reducers/productReducers';
import { IProduct } from '../types/productType';
import IndividualProduct from './IndividualProduct';
import { usePagination } from "../hooks/usePagination"
import { AnatherBox, AnatherInputLabel, AnatherMenuItem, AnatherSelect, CategoryBox, OuterBox, ProductBox } from '../styledComponent/productstyle';

const Products = () => {
  const { id } = useParams();
  const [selCategory, setSelCategory] = useState<number[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [numbofPages, setNumbofPages] = useState(12);
  const [search, setSearch] = useState({ search: "" });
  const dispatch = useAppDispatch();
  const displayNewProducts = (state: RootState) => {
    let data, newData;

    let filteredData: IProduct[] = [];
    if (selCategory.length > 0) {
      for (let i = 0; i < selCategory.length; i++) {
        [...data] = state.productReducer.product.filter((product: IProduct) => { return product.category.id === selCategory[i] && product.title.toLocaleLowerCase().includes(search.search.toLocaleLowerCase()) })
        filteredData.push(...data)
      }
      return filteredData;
    }
    else if (search.search !== "") {
      [...data] = state.productReducer.product.filter((product: IProduct) => product.title.toLocaleLowerCase().includes(search.search.toLocaleLowerCase()))
      filteredData.push(...data)
      return filteredData;
    } else {
      return state.productReducer.product;
    }
  }
  const products = useAppSelector(state => { return displayNewProducts(state) })
  const searchText = (field: string, e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setSearch((prevVal) => ({ ...prevVal, [field]: e.target.value }));
  }
  //pagination change event.
  const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setCurrentPage(value);
    dataPaginated.gotoPage(value)
  };
  const handleNumbSelect = (e: SelectChangeEvent<unknown>) => {
    setNumbofPages(Number(e.target.value))
  }
  const handleChange = (e: SelectChangeEvent<unknown>) => {
    if (e.target.value === "a-z") {
      dispatch(ascendingOrder("asc"))
    } else if (e.target.value === "z-a") {
      dispatch(ascendingOrder("desc"))
    }
    else if (e.target.value === "hightolow") {
      dispatch(sortByPrice("hightolow"))
    }
    else {
      dispatch(sortByPrice("lowtohigh"))
    }
  }
  const dataPaginated = usePagination(numbofPages, products);
  //New products array returned by usePagination hook.
  const newProducts: IProduct[] = []
  dataPaginated.currentPageData().map((data) => { return newProducts.push(data) })
  //total slots that needs to be displayed
  const totalDisplayed = dataPaginated.totalPages;
  if (id) {
    return (
      <>
        <IndividualProduct products={products} />
      </>
    )
  } else {
    return (
      <>
        <AnatherBox sx={{ backgroundColor: 'primary.main' }}>
          <CategoryBox>
            <Category setSelCategory={setSelCategory} selCategory={selCategory} />
            <Box display="flex" flexDirection="column" sx={{ color: 'text.primary' }}>
              <Box sx={{ color: 'text.primary' }}>
                Looking for something?
              </Box>
              <br />
              <Box>
                <input type="text" placeholder="Search" name="search" value={search.search} onChange={(e) => searchText('search', e)} />
              </Box>
            </Box>
          </CategoryBox>
          <ProductBox>
            <OuterBox>
              <Grid container spacing={2}>
                <Grid item xs={5}></Grid>
                <Grid sx={{ color: 'text.primary' }} item xs={3}>{products.length} products displayed</Grid>
                {/* <Grid item xs={5}></Grid> */}
                <Grid item xs={4}>
                  <Grid container spacing={0} display="flex" flexDirection="row">
                    <Grid item xs={6}> <FormControl fullWidth>
                      <AnatherInputLabel id="select-label-sort">Sorting</AnatherInputLabel>
                      <AnatherSelect
                        labelId="select-label-sort"
                        id="select-label-sort"
                        value=""
                        label="Sorting"
                        onChange={(e) => handleChange(e)}
                      >
                        <AnatherMenuItem value="a-z">a-z</AnatherMenuItem>
                        <AnatherMenuItem value="z-a">z-a</AnatherMenuItem>
                        <AnatherMenuItem value="hightolow">Price(Low to High)</AnatherMenuItem>
                        <AnatherMenuItem value="lowtohigh">Price(High to Low)</AnatherMenuItem>
                      </AnatherSelect>
                    </FormControl></Grid>
                    <Grid item xs={6}>
                      <FormControl fullWidth>
                        <AnatherInputLabel id="select-label-sort">Items/Pages</AnatherInputLabel>
                        <AnatherSelect
                          labelId="select-label-sort"
                          id="select-label-sort"
                          value=""
                          label="Pages"
                          onChange={(e) => handleNumbSelect(e)}
                        >
                          <AnatherMenuItem value="12">12</AnatherMenuItem>
                          <AnatherMenuItem value="24">24</AnatherMenuItem>
                          <AnatherMenuItem value="36">36</AnatherMenuItem>
                          <AnatherMenuItem value="48">48</AnatherMenuItem>
                        </AnatherSelect>
                      </FormControl>
                    </Grid>
                  </Grid>
                </Grid>
              </Grid>
            </OuterBox>
            <Box sx={{ backgroundColor: 'primary.main' }}>
              <ProductList products={products} />
            </Box>
          </ProductBox>
        </AnatherBox>
        <Grid container display="flex" spacing={0} direction="row" alignItems="center" justifyContent="center" style={{ minHeight: '1vh', minWidth: '100vw', backgroundColor: 'primary.main', width: '100%' }}>
          <Pagination count={totalDisplayed} onChange={handlePageChange} sx={{ backgroundColor: 'primary.main' }} />
        </Grid>
      </>
    )
  }
}

export default Products