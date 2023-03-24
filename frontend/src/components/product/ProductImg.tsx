import React, { useState } from 'react'
import styled from '@emotion/styled';
import { Box, Typography } from '@mui/material';
import { ICategory, imageLink } from '../../types/productType';

const ProductImg = ({ images, image }: { images: imageLink[], image: ICategory }) => {

    const [mainImg, setMainImg] = useState(image.image)
    const changeData = (e: React.MouseEvent<HTMLImageElement, MouseEvent>, imagedata: string) => {
        setMainImg(imagedata);
    }
    const Boxfirst = styled(Box)({
        display: "flex",
        flexDirection: "column",
        width: "250px",
        justifyContent: "center"
    })
    const Boxsecond = styled(Box)({
        display: "flex",
        flexDirection: "column",
        width: "250px",
        justifyContent: "center"
    })
    return (
        <>
            <Boxfirst>
                {<img src={image.image} alt={image.image} key={image.id} width="150" height="150" onClick={(e) => changeData(e, image.image)} />}
                {images.map((data, key) => <img key={key} src={data.imageURL} alt={data.imageURL} width="150" height="150" onClick={(e) => changeData(e, data.imageURL)} />)}
            </Boxfirst>
            <Boxsecond>
                {<img src={mainImg} alt={mainImg} width="250" height="250" />}
            </Boxsecond>
        </>
    )
}

export default ProductImg