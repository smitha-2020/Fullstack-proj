import { AiOutlineStar } from "react-icons/ai"
import { Box } from "@mui/material";

import { FaStarHalfAlt, FaStar } from "react-icons/fa";

const Star = () => {
    const star = 4.5;
    const ratingStar = Array.from({ length: 5 }, (v, i) => {
        let number = i + 0.5; // 0.5,1.5,2.5...
        return (<>
            <Box component="span" m="{1}" key={i.toString()}>{star >= i + 1 ? <FaStar className="icons" /> : star >= number ? <FaStarHalfAlt  className="icons"/> : <AiOutlineStar className="icons"/>}</Box>
        </>)
    });
    return(<Box key={star+'id'}>{ratingStar}</Box>)
}

export default Star