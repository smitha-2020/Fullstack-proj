import { Box,Grid } from '@mui/material'
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import styled from "@emotion/styled";

const ToggleButton = ({ amount, setIncrease, setDecrease }: { amount: number, setIncrease: () => void, setDecrease: () => void }) => {

    const MainBox = styled(Box)({
        display: "flex",
        flexDirection: "row",
        marginTop:"50px",
        gap:"30px",
        justifyContent: "center",
      });
    return (
        <div>

<Grid container spacing={0} direction="row" alignItems="center" justifyContent="center" style={{width:"200px", marginTop:"20px"}}>
    <Grid item xs={4}><RemoveIcon onClick={setDecrease}/></Grid>
    <Grid item  xs={4}>{amount}</Grid>
    <Grid item  xs={4}><AddIcon onClick={setIncrease}/></Grid>
</Grid>
            {/* <MainBox>
                <Box><RemoveIcon onClick={setDecrease}/></Box>
                <Box>{amount}</Box>
                <Box><AddIcon onClick={setIncrease}/></Box>
            </MainBox> */}

        </div>
    )
}

export default ToggleButton