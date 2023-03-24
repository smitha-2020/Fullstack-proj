import { ICategory } from "../types/productType"

export const newcartProduct = {
    quantity: 3,
    product: {
        id: 39,
        title: "Oriental Steel Pizza",
        price: 49,
        description: "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
        images: [
            "https://api.lorem.space/image/shoes?w=640&h=480&r=3013",
            "https://api.lorem.space/image/shoes?w=640&h=480&r=9536",
            "https://api.lorem.space/image/shoes?w=640&h=480&r=4429"
        ],
        category: {
            id: 4,
            name: "Shoes",
            image: "https://api.lorem.space/image/shoes?w=640&h=480&r=7041",

        }
    },
    userInfo: {
        avatar: "https://api.lorem.space/image/face?w=640&h=480&r=3197",
        email: "john@mail.com",
        id: 1,
        name: "Jhon",
        password: "changeme",
        role: "customer",
    }
}
export const data = {
    id: 1,
    updateProduct: {
        title: "Change title",
        price: 100
    }
}
export const products = [
    {
        id: 13,
        title: "Incredible Metal Bacon",
        price: 317,
        description: "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
        images: [
            "https://api.lorem.space/image/watch?w=640&h=480&r=9003",
            "https://api.lorem.space/image/watch?w=640&h=480&r=375",
            "https://api.lorem.space/image/watch?w=640&h=480&r=6293"
        ],
        category: {
            id: 2,
            name: "Electronics",
            image: "https://api.lorem.space/image/watch?w=640&h=480&r=9863",
        }
    },
    {
        id: 12,
        title: "Awesome Frozen Salad",
        price: 444,
        description: "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
        images: [
            "https://api.lorem.space/image/watch?w=640&h=480&r=8808",
            "https://api.lorem.space/image/watch?w=640&h=480&r=6980",
            "https://api.lorem.space/image/watch?w=640&h=480&r=1512"
        ],
        category: {
            id: 2,
            name: "Electronics",
            image: "https://api.lorem.space/image/watch?w=640&h=480&r=6865",
        }
    },
    {
        id: 1,
        title: "Twesome Frozen Salad22",
        price: 600,
        description: "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
        images: [
            "https://api.lorem.space/image/watch?w=640&h=480&r=8808",
            "https://api.lorem.space/image/watch?w=640&h=480&r=6980",
            "https://api.lorem.space/image/watch?w=640&h=480&r=1512"
        ],
        category: {
            id: 1,
            name: "Electronics",
            image: "https://api.lorem.space/image/watch?w=640&h=480&r=6865",
        }
    },
]
export const categoryList:ICategory[] = [
    {
        id: 1,
        name: "Clothes",
        image: "https://api.lorem.space/image/fashion?w=640&h=480&r=5664",
    },
    {
        id: 2,
        name: "Electronics",
        image: "https://api.lorem.space/image/watch?w=640&h=480&r=6002",
    },
    {
        id: 3,
        name: "Furniture",
        image: "https://api.lorem.space/image/furniture?w=640&h=480&r=5292",

    }
]
export const updatecategory: ICategory = {
    id: 1,
    name: "Testing Cloths",
    image: "https://api.lorem.space/image/fashion?w=640&h=480&r=2301",
}
export const users = [

    {
        id: 1,
        email: "john@mail.com",
        password: "changeme",
        name: "Jhon",
        role: "customer",
        avatar: "https://api.lorem.space/image/face?w=640&h=480&r=7996",
    },
    {
        id: 2,
        email: "maria@mail.com",
        password: "12345",
        name: "Maria",
        role: "customer",
        avatar: "https://api.lorem.space/image/face?w=640&h=480&r=9636",
    },
    {
        id: 3,
        email: "admin@mail.com",
        password: "admin123",
        name: "Admin",
        role: "admin",
        avatar: "https://api.lorem.space/image/face?w=640&h=480&r=3204",
    }
]
export const createUserObjs = {
    email: "nicoo@gmail.com",
    password: "1234",
    name: "Nicolas",
    avatar: "https://api.lorem.space/image/face?w=640&h=480&r=867",
    role: "customer",
    id: 24
}