import { rest } from "msw";
import { setupServer } from "msw/node";
import { IProduct, IProductDesc } from "../../types/productType";
import { ICategory } from "../../types/productType";
import {
  products,
  categoryList,
  users,
  createUserObjs,
} from "../../common/data";
import { IAuthenticUser } from "../../types/userType";

const handler = [
  rest.get("https://localhost:5001/products/all", (req, res, ctx) => {
    return res(ctx.json(products));
  }),
  rest.put(
    "https://localhost:5001/products/:id",
    async (req, res, ctx) => {
      const product: Partial<IProduct> = await req.json();
      const { id } = req.params;
      const foundProduct = products.find(
        (reqProduct) => reqProduct.id === Number(id)
      );
      if (foundProduct) {
        return res(
          ctx.json({
            ...foundProduct,
            ...product,
          })
        );
      } else {
        return res(ctx.status(404, "Np product found"));
      }
    }
  ),
  // rest.put(
  //   "https://api.escuelajs.co/api/v1/categories/:id/products",
  //   (req, res, ctx) => {
  //     const { id } = req.params;
  //     const foundProduct: IProduct[] = products.filter((reqProduct) => {
  //       return reqProduct.category.id === Number(id);
  //     });
  //     if (foundProduct) {
  //       return res(
  //         ctx.json({
  //           ...foundProduct,
  //         })
  //       );
  //     } else {
  //       return res(ctx.status(404, "Np product found"));
  //     }
  //   }
  // ),
  rest.post(
    "https://localhost:5001/products",
    async (req, res, ctx) => {
      const product: IProductDesc = await req.json();
      if (product.price < 0) {
        return res(ctx.status(400, "invalid data"));
      } else {
        return res(
            ctx.json({
              product,
            })
          );
      }
   }
  ),
  // rest.delete(
  //   "https://api.escuelajs.co/api/v1/products/:id",
  //   async (req, res, ctx) => {
  //     const { id } = req.params;
  //     const remainingProduct: IProduct[] = products.filter((reqProduct) => {
  //       return reqProduct.id !== Number(id);
  //     });
  //     return res(
  //       ctx.json({
  //         ...remainingProduct,
  //       })
  //     );
  //   }
  // ),
  rest.get(
    "https://localhost:5001/categorys",
    async (req, res, ctx) => {
      return res(ctx.json(categoryList));
    }
  ),
  rest.get(
    "https://api.escuelajs.co/api/v1/categories/:id",
    async (req, res, ctx) => {
      const { id } = req.params;
      const foundCategory = categoryList.filter((category) => {
        return category.id === Number(id);
      });
      return res(ctx.json(foundCategory));
    }
  ),
  rest.post(
    "https://api.escuelajs.co/api/v1/categories/",
    async (req, res, ctx) => {
      const category: ICategory = await req.json();
      return res(ctx.json(category));
    }
  ),
  rest.put(
    "https://api.escuelajs.co/api/v1/categories/:id",
    async (req, res, ctx) => {
      const { id } = req.params;
      const foundCategory = categoryList.find(
        (reqProduct: ICategory) => reqProduct.id === Number(id)
      );
      const newcategory: ICategory = await req.json();
      if (foundCategory) {
        return res(
          ctx.json({
            ...foundCategory,
            ...newcategory,
          })
        );
      } else {
        return res(ctx.status(404, "Np product found"));
      }
    }
  ),
  rest.delete(
    "https://api.escuelajs.co/api/v1/categories/:id",
    async (req, res, ctx) => {
      const { id } = req.params;
      const foundCategory: ICategory[] = categoryList.filter((reqProduct) => {
        return reqProduct.id === Number(id);
      });
      return res(ctx.json(foundCategory));
    }
  ),
  rest.get("https://api.escuelajs.co/api/v1/users", async (req, res, ctx) => {
    return res(ctx.json(users));
  }),
  rest.get(
    "https://api.escuelajs.co/api/v1/users/:id",
    async (req, res, ctx) => {
      const { id } = req.params;
      const user = users.filter((singleUser) => {
        return singleUser.id === Number(id);
      });
      return res(ctx.json(user));
    }
  ),
  rest.post("https://api.escuelajs.co/api/v1/users/", async (req, res, ctx) => {
    const createUserNew = createUserObjs;
    return res(ctx.json(createUserNew));
  }),
  rest.put(
    "https://api.escuelajs.co/api/v1/users/:id",
    async (req, res, ctx) => {
      const { idUrl } = req.params;
      const reqData = await req.json();
      //console.log(reqData.id)
      const { id, ...filteredData } = reqData;
      const foundUser: IAuthenticUser[] = users.filter((user) => {
        return user.id === Number(idUrl);
      });
      const [found] = foundUser;
      if (found) {
        //console.log({...found,...filteredData})
        return res(
          ctx.json({
            ...found,
            ...filteredData.user,
          })
        );
      } else {
        return res(ctx.status(404, "Np product found"));
      }
    }
  ),
];

const server = setupServer(...handler);
export default server;
