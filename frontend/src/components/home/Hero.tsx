import { Button } from '@mui/material'
import { NavLink } from 'react-router-dom'
import { HeroContainer, HeroItem, HeroText, HeroTypography } from '../../styledComponent/home'
import FavoriteIcon from '@mui/icons-material/Favorite';

const Hero = () => {
  return (
    <>
      <HeroContainer>
        <HeroItem>
          <HeroTypography sx={{ color: 'text.primary' }}>Welcome to my store</HeroTypography>
          <HeroText>
            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
            when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic
            typesetting, remaining essentially unchanged.
          </HeroText>
          <Button sx={{ color: 'white', textAlign: 'center' }}>
            <NavLink to="/products" className="NavBtn">Products</NavLink>
          </Button>
        </HeroItem>
        <HeroItem>
          <FavoriteIcon sx={{fontSize:'400px'}}/>
         
        </HeroItem>
      </HeroContainer>

    </>
  )
}

export default Hero