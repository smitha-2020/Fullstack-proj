import { useParams } from "react-router-dom";

import { ICategory, imageLink, IProduct } from "../types/productType";
import { RootState } from "../redux/store";
import { Grid } from "@mui/material";
import ProductImg from "../components/product/ProductImg";
import LocalShippingIcon from "@mui/icons-material/LocalShipping";
import AutorenewIcon from "@mui/icons-material/Autorenew";
import SecurityIcon from "@mui/icons-material/Security";
import AddToCart from "../components/cart/AddToCart";
import Star from "../components/cart/Star";


const IndividualProduct = ({ products }: { products: IProduct[] }) => {
  let { id } = useParams();
  let images: imageLink[] = [];
  let img: ICategory = {id: 0, name: "", image: "" };
  let userId:string = "fb23e582-09e3-46ed-b471-410ff012b2d7";
  // let rating: number = 0;
  // let reviews: number = 0;
  //let image: Category = { id: 0, name: "", image: "" };
  let price,
    description,
    title: string = "";
  const displayoneProduct = (state: RootState) => {
    let filteredData: IProduct[] = [];
    //console.log(filteredData)
    // [...data] = state.productReducer.filter((product) => {
    //   return product.id === Number(id);
    // });
    // filteredData.push(...data);
    return filteredData;
  };

  const product = products.filter((product) => { return product.id === Number(id) })
  const [newdata] = product;
  if (product) {
    product.map((data) => {
      img = data.category
      images = data.imageLink;
      price = data.price;
      description = data.description;
      title = data.title;
      // rating = data.rating.rate;
      // reviews = data.rating.count;
    })
  }

  if (price && description && title) {
    let idPass: string = (id) ? id : "";
  
    return (
      <>
        <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ minHeight: '100vh', minWidth: '100vw',backgroundColor:'primary.main' }}>
          <Grid container spacing={0} alignItems="center" justifyContent="center" sx={{ width: '1200px', height: '500px', marginLeft: "20px" }}>
            {/* <Grid item xs={5}> <img src={img} alt={img} width="250" height="250" /></Grid> */}
            <Grid item xs={5}>
              <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center">
                <ProductImg images={images} image={img}/>
              </Grid>
            </Grid>
            <Grid item xs={1}></Grid>
            <Grid item xs={6}>
              <Grid container spacing={0} direction="column" >
                <Grid item sx={{ marginTop: '10px', fontSize: '25px', fontWeight: '400' }}>{title}</Grid>
                <Grid item sx={{ marginTop: '20px',fontSize:'12px',fontWeight:'400' }}> <Star/></Grid>
                <Grid item sx={{ marginTop: '10px',fontSize:'12px',fontWeight:'400' }}> ({price} reviews so far)</Grid>
                <Grid item sx={{ marginTop: '10px', fontSize: '18px', fontWeight: '400' }}>Price : ${price}</Grid>
                <Grid item sx={{ marginTop: '10px', fontSize: '12px', fontWeight: '400', width: "500px" }}>{description}</Grid>
                <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" sx={{ marginTop: '30px' }}>
                  <Grid item xs={3}>
                    <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" sx={{ fontSize: '10px', fontWeight: '400' }}>
                      <Grid item><LocalShippingIcon /></Grid>
                      <Grid item> Fast Delivery</Grid>
                    </Grid>
                  </Grid>
                  <Grid item xs={3}>
                    <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" sx={{ fontSize: '10px', fontWeight: '400' }}>
                      <Grid item></Grid> <AutorenewIcon />
                      <Grid item>30day replacement</Grid>
                    </Grid>
                  </Grid>
                  <Grid item xs={3}>
                    <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" sx={{ fontSize: '10px', fontWeight: '400' }}>
                      <Grid item><LocalShippingIcon /></Grid>
                      <Grid item> Fast Delivery</Grid>
                    </Grid>
                  </Grid>
                  <Grid item xs={3}>
                    <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" sx={{ fontSize: '10px', fontWeight: '400' }}>
                      <Grid item>  <SecurityIcon /></Grid>
                      <Grid item>2 year warrenty</Grid>
                    </Grid>
                  </Grid>
                </Grid>
                <Grid item sx={{ marginTop: '20px', fontSize: '12px', fontWeight: '400' }}>Available : In stock</Grid>
                <Grid item sx={{ marginTop: '20px', fontSize: '12px', fontWeight: '400' }}>ID : {id}</Grid>
                <Grid item sx={{ marginTop: '20px', fontSize: '12px', fontWeight: '400' }}>Brand: {title}</Grid>
                <Grid item sx={{ border: "1px solid gray", marginTop: '20px' }}></Grid>
                <Grid item>
                  <AddToCart products={newdata} id={idPass} userId={userId} />
                </Grid>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </>
    )
  } else {
    return (
      <>
        <Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" style={{ minHeight: '100vh', minWidth: '100vw' }}>
          No products by this Id
        </Grid>
      </>
    )
  };
}
export default IndividualProduct;
