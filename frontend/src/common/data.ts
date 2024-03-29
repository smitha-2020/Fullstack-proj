import { ICategory } from "../types/productType";

export const newcartProduct = {

};
export const data = {
  id: 1,
  updateProduct: {
    title: "Change title",
    price: 100,
  },
};
export const products = [
  {
    id: 29,
    title: "Best Home Trendy Furniture",
    price: 500,
    description: "Best Home Trendy Furniture",
    categoryId: 16,
    category: {
      id: 16,
      name: "Furniture",
      image:
        "https://cdn.lorem.space/images/furniture/.cache/640x480/paul-weaver-nWidMEQsnAQ-unsplash.jpg",
    },
    imageLink: [
      {
        id: 47,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/scopic-ltd-NLlWwR4d3qU-unsplash.jpg",
      },
      {
        id: 48,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/vincent-botta-J41ffLK_OSM-unsplash.jpg",
      },
      {
        id: 49,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/minh-pham-OtXADkUh3-I-unsplash.jpg",
      },
    ],
  },
  {
    id: 26,
    title: "Sofesticated Artificial Pink Floral skirt",
    price: 100,
    description: "SofesticatedArtificial Pink Floral skirt",
    categoryId: 2,
    category: {
      id: 2,
      name: "Women's Clothing",
      image: "https://source.unsplash.com/164_6wVEHfI",
    },
    imageLink: [
      {
        id: 37,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/rabie-madaci-4iwG8QD17AE-unsplash.jpg",
      },
      {
        id: 39,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/eugene-chystiakov-3neSwyntbQ8-unsplash.jpg",
      },
      {
        id: 40,
        imageURL:
          "https://cdn.lorem.space/images/furniture/.cache/640x480/minh-pham-OtXADkUh3-I-unsplash.jpg",
      },
    ],
  },
  {
    id: 27,
    title: "Trendy Jacket With Diamond Studs",
    price: 500,
    description: "Trendy Jacket With Diamond Studs",
    categoryId: 2,
    category: {
      id: 2,
      name: "Women's Clothing",
      image: "https://source.unsplash.com/164_6wVEHfI",
    },
    imageLink: [
      {
        id: 41,
        imageURL:
          "https://cdn.lorem.space/images/fashion/.cache/640x480/mike-von-TPUGbQmyVwE-unsplash.jpg",
      },
      {
        id: 42,
        imageURL:
          "https://cdn.lorem.space/images/fashion/.cache/640x480/wesley-tingey-3mGnYRUNIck-unsplash.jpg",
      },
      {
        id: 43,
        imageURL:
          "https://cdn.lorem.space/images/fashion/.cache/640x480/brooke-cagle-z1B9f48F5dc-unsplash.jpg",
      },
    ],
  },
];
export const categoryList: ICategory[] = [
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
  },
];
export const updatecategory: ICategory = {
  id: 1,
  name: "Testing Cloths",
  image: "https://api.lorem.space/image/fashion?w=640&h=480&r=2301",
};
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
  },
];
export const createUserObjs = {
  email: "nicoo@gmail.com",
  password: "1234",
  name: "Nicolas",
  avatar: "https://api.lorem.space/image/face?w=640&h=480&r=867",
  role: "customer",
  id: 24,
};

export const createProductObjs = {
    id: 100,
    title: "Black Sleek and Stylish Apple Watch",
    price: 3300,
    description: "Black Sleek and Stylish Apple Watch",
    categoryId: 3,
    category: {
      id: 3,
      name: "Watches",
      image: "https://cdn.lorem.space/images/watch/.cache/640x480/sincerely-media-fogkyNSMBAk-unsplash.jpg"
    },
    imageLink: [
      {
        id: 85,
        imageURL: "https://res.cloudinary.com/dllghhg4r/image/upload/v1680343445/geekyimages/cau1jejdf2mol94iymqi.jpg"
      },
      {
        id: 86,
        imageURL: "https://res.cloudinary.com/dllghhg4r/image/upload/v1680343448/geekyimages/o4qqefqqiys8we7piep1.jpg"
      },
      {
        id: 87,
        imageURL: "https://res.cloudinary.com/dllghhg4r/image/upload/v1680343451/geekyimages/ljiuao5abgelxfffdzxe.jpg"
      }
    ]
  }

