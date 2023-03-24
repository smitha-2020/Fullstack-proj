import { Box, InputLabel, MenuItem, Select, SelectChangeEvent, Grid, Pagination } from '@mui/material';
import styled from '@emotion/styled';

// styled utility from materialui for product page
export const AnatherBox = styled(Box)({
  display: "flex",
  flexDirection: "row",
  gap: "10px",
  padding: "50px 0 0 50px",
  minHeight: '81vh'
})
export const AnatherInputLabel = styled(InputLabel)({
  fontSize: "10px"
})
export const AnatherSelect = styled(Select)({
  width: "200px",
  float: "right",
  fontSize: "10px",
  height: "40px"
})
export const AnatherMenuItem = styled(MenuItem)({
  fontSize: "12px"
})
export const CategoryBox = styled(Box)({
  display: "flex",
  flexDirection: "column",
  gap: "20px",
  minWidth: "200px",
  fontSize: "12px"
})
export const OuterBox = styled(Box)({
  marginBottom: "20px"
})
export const ProductBox = styled(Box)({
  display: "flex",
  flexDirection: "column",
})

// styled component for displaying card on products page and home page
export const ProductListing = styled(Box)({
  display: "flex",
  flexDirection: "row",
  gap: "10px",
  flexWrap: "wrap",
  width: "1200px",
  margin: "0 0 0 200px",
});
export const CategorySBox = styled(Box)({
  minWidth: "100px",
  width: "auto",
  color: "lightgray",
  backgroundColor: "white",
  padding: "5px",
  fontSize: "10px",
  borderRadius: "1em",
  position: "absolute",
  top: "25px",
  right: "25px"
});
export const Card = styled(Box)({
  display: "flex",
  flexDirection: "column",
  textAlign: "center",
  gap: "20px",
  minWidth: "250px",
  minHeight: "250px",
  backgroundColor: "#f2f2f2",
  justifyContent: "center",
  alignItems: "center",
  marginBottom: "25px",
  position: "relative"
});
export const NameBox = styled(Box)({
  fontSize: "12px",
});
export const DescriptionBox = styled(Box)({
  fontSize: "12px",
  display: "flex",
  flexDirection: "row",
  gap: "20px"
});
export const ImgBox = styled(Box)({
  width: "90%",
  height: "80%",
});
export const NotFound = styled(Grid)({
  minHeight: '84vh',
  height: 'auto',
  minWidth: '70vw',
  marginTop: '5px',
  display:"flex",
  flexDirection:"row",
  alignItems: "center",
  justifyContent: "center"

});

