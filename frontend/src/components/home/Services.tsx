import { SericesItem, SericesSection, Servicesfont } from '../../styledComponent/home'
import LocalShippingIcon from '@mui/icons-material/LocalShipping';
import VolunteerActivismIcon from '@mui/icons-material/VolunteerActivism';
import MonetizationOnIcon from '@mui/icons-material/MonetizationOn';

const Services = () => {
    return (
        <>
            <SericesSection>
                <SericesItem>
                    <LocalShippingIcon sx={{ fontSize: '8px', width: '100px', height: '100px', borderRadius: '50%', backgroundColor: 'white', padding: '20px' }} />
                    {/* <FavoriteIcon className="centered-icon" sx={{fontSize:'8px',width:'100px',height:'100px',borderRadius:'50%',backgroundColor:'white',padding:'20px'}} /> */}
                    <Servicesfont>Super fast and free delivery</Servicesfont>
                </SericesItem>
                <SericesItem>
                    <MonetizationOnIcon sx={{ fontSize: '8px', width: '100px', height: '100px', borderRadius: '50%', backgroundColor: 'white', padding: '20px' }} />
                    {/* <FavoriteIcon className="centered-icon" sx={{fontSize:'8px',width:'100px',height:'100px',borderRadius:'50%',backgroundColor:'white',padding:'20px'}} /> */}
                    <Servicesfont>Value for money</Servicesfont>
                </SericesItem>
                <SericesItem>
                    <VolunteerActivismIcon sx={{ fontSize: '8px', width: '100px', height: '100px', borderRadius: '50%', backgroundColor: 'white', padding: '20px' }} />
                    <Servicesfont>Money back guarentee</Servicesfont>
                </SericesItem>
            </SericesSection>
        </>
    )
}

export default Services