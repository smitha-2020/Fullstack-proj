import { useTheme } from '@mui/material/styles';
import { HeroSection } from '../styledComponent/home';
import Hero from '../../src/components/home/Hero'
import Services from '../components/home/Services';
import Partners from '../components/home/Partners';
import Featured from '../components/home/Featured';

//static page which displays only some categories
const Home = () => {
  const theme = useTheme();
  return (
    <>
      <HeroSection sx={{backgroundColor:'primary.main'}}>
        <Hero/>
        <Featured/>
        <Services/>
        <Partners/>
      </HeroSection>
    </>
  )
}

export default Home