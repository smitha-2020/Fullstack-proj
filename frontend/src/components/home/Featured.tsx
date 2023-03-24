import { NavLink } from 'react-router-dom'
import { useAppSelector } from '../../hooks/reduxHook'
import { SericesSection } from '../../styledComponent/home'
import { Card, CategorySBox, DescriptionBox, ImgBox, NameBox } from '../../styledComponent/productstyle'

const Featured = () => {
    const categories = useAppSelector(state => state.categoryReducers)
    //const categortList = ["electronics"]
    //const newcategories = categories.filter((category) => { return (categortList.includes(category.name.toLowerCase())) })
    //const newcategories = categories.filter((category) => { return category})
    const slicedArray = categories.slice(0, 5);


    // // #e6f2ff
    return (
        <>
            <SericesSection sx={{backgroundColor:'gray'}}>
                {slicedArray.map((element) =>(
                     <Card key={element.id} sx={{color:'text.primary'}}>
                     <ImgBox>
                     <NavLink to='/products' ><img width="220" height="180" src={element.image} alt={element.image} /></NavLink>
                       {/* <Link href={`/product/${element.id}`} ><img width="220" height="180" src={element.image} alt={element.image}/></Link> */}
                     </ImgBox>
                     <CategorySBox>{element.name}</CategorySBox>
                   </Card>
                ))}
           
            </SericesSection>

        </>
    )
}

export default Featured