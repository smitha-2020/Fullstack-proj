import { useState } from "react";

import { IProduct } from "../types/productType";

//cardsPerPage,totalCards
export const usePagination = (cardsPerPage: number, cards: IProduct[]) => {
    const totalPages = Math.ceil(cards.length / cardsPerPage);
    const [currentPageIndex, setcurrentPageIndex] = useState(1);
    //function
    const gotoPage = (page: any) => {
        const pageNumber = Math.max(1, page)
        setcurrentPageIndex(Math.min(pageNumber, totalPages))
    }
    const currentPageData = (): IProduct[] => {
        const start = (currentPageIndex - 1) * cardsPerPage
        const end = start + cardsPerPage
        return cards.slice(start, end)
    }
    return { totalPages, currentPageIndex,currentPageData, gotoPage }

};