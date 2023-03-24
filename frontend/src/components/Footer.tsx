import { AppBar, Box, Button, Container, Toolbar } from '@mui/material';
import LinkedInIcon from '@mui/icons-material/LinkedIn';
import { NavLink } from 'react-router-dom';

const Footer = () => {
    return (
        <>
             <AppBar position="static" sx={{ backgroundColor: 'white', color: 'lightgray',marginBottom:'-100px' }}>
                <Container maxWidth="xl">
                    <Toolbar disableGutters>    
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }}} flexDirection="row" justifyContent="center" >
                            <Button sx={{ my: 2, color: 'gray', display: 'block' }}>
                                <NavLink to="/" style={{ color: 'gray' }}>Home</NavLink>
                            </Button>
                            <Button sx={{ my: 2, color: 'gray', display: 'block' }}>
                                <NavLink to="/products" style={{ color: 'gray' }}>Products</NavLink>
                            </Button>
                            <Button sx={{ my: 2, color: 'gray', display: 'block' }}>
                               <a href="https://www.linkedin.com/in/smitha-kamath/"><LinkedInIcon/></a>
                            </Button>
                        </Box>
                    </Toolbar>
                </Container>
            </AppBar>
        </>
    )
}

export default Footer