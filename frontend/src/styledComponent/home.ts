import { Box, Typography, Button } from '@mui/material';
import styled from '@emotion/styled';

// styled utility from materialui for home page top section
export const HeroSection = styled(Box)({
  minHeight: '88vh',
  height: 'auto',
  minWidth: '100vw',
  color: 'lightgray',
  display: 'flex',
  flexDirection: 'column',
  alignItems: "center",
  justifyContent: "center"
})
export const HeroContainer = styled(Box)({
  minHeight: '88vh',
  height: 'auto',
  minWidth: '100vw',
  color: 'lightgray',
  display: 'flex',
  flexDirection: 'row',
  alignItems: "center",
  justifyContent: "center",
  gap: "50px",

})
export const HeroItem = styled(Box)({
  minHeight: '30vh',
  height: 'auto',
  width: '500px',
  color: 'gray',
  alignItems: "center",
  justifyContent: "center",
  gap: "50px",
  // backgroundColor:'pink'
})
// export const HeroItemRight = styled(Box)({
//     minHeight: '30vh',
//     height: 'auto',
//     width: '500px',
//     color: 'gray',
//     alignItems: "center",
//     justifyContent: "center",
//     gap:"50px",
//     backgroundColor:'pink'
// })
export const HeroTypography = styled(Typography)({
  fontSize: '20px',
  fontWeight: 'bold',
  textAlign: 'center',
})
export const HeroText = styled(Typography)({
  fontSize: '12px',
  fontWeight: 'bold',
  textAlign: 'center',
})
export const HeroBtn = styled(Button)({
  fontSize: '12px',
  fontWeight: 'bold',
  textAlign: 'center',
})
// styled utility from materialui for home page services section
export const SericesSection = styled(Box)({
  minHeight: '40vh',
  height: 'auto',
  minWidth: '100vw',
  color: '#cccccc',
  display: 'flex',
  flexDirection: 'row',
  alignItems: "center",
  justifyContent: "center",
  gap: "50px",
})
export const SericesItem = styled(Box)({
  minHeight: '30vh',
  height: 'auto',
  width: '300px',
  display: 'flex',
  flexDirection: 'column',
  color: 'gray',
  alignItems: "center",
  justifyContent: "center",
  gap: "60px",
  backgroundColor: '#f2f2f2',
  borderRadius: '5px'
})
export const ItemImg = styled(Box)({
  minHeight: '100%',
  height: 'auto',
  width: '300px',
  color: 'gray',
  alignItems: "center",
  justifyContent: "center",
  gap: "60px",
  backgroundColor: 'pink'
})
export const Servicesfont = styled(Typography)({
  fontSize: '12px'
})
export const PartnerSection = styled(Box)({
  width: '1000px',
  height: '200px',
  backgroundColor: '#f2f2f2',
  borderRadius: '5px',
  display: 'flex',
  flexDirection: 'column',
  rowGap: '20px'
})
export const PartnerItem = styled(Box)({
  width: '150px',
  height: '150px',
  display: 'flex',
  justifyContent: 'center',
  alignItems: 'center',
  fontSize: '40px',
  fontWeight:'bold'
  // backgroundColor:'pink'
})
export const Partnertext = styled(Typography)({
  width: '1000px',
  height: '20px',
  display: 'flex',
  justifyContent: 'center',
  alignItems: 'center',
  padding: '40px 0 0 0',
  fontSize: '12px',
  fontWeight: 'bold'

})
export const PartnerRow = styled(Box)({
  display: 'flex',
  flexDirection: 'row',
  justifyContent: 'center',
  alignItems: 'center',

})




