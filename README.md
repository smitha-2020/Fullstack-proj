# Fullstack Project

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

* Frontend: SASS, TypeScript, React, Redux Toolkit
* Backend: ASP .NET Core, Entity Framework Core, PostgreSQL

# FrontEnd

- Developed Endpoints for the ECommerce website.
- PostgreSQL as Database.
- EFCore ORM for connecting c# application to database.

Description:

- MiddleWare.
- Authentication and Role based Authorization using IdentityFramework.
- AutoMapper for mapping across different requirement.
- ValidationAttribute for validating of DTO's.
- Custom Validation of DTOs.
- Made use of OOPs concepts(Encapsulation,Inheritance).
- Used Migration.


Endpoints:
Category:
```sh
GET https://localhost:5001/categorys
GET https://localhost:5001/categorys/{id}
POST https://localhost:5001/categorys
PUT https://localhost:5001/categorys/{id}
DELETE  https://localhost:5001/categorys/{id}
```
Product:

```sh
POST https://localhost:5001/products
GET https://localhost:5001/products/all
GET https://localhost:5001/products?Search={searchtext}&SortByProperty={property}&CardsPerPage={pageend}&Page={pagestart}&Sort={sortorder}
GET https://localhost:5001/products/{id}
GET https://localhost:5001/categorys/{id}/products 
PUT https://localhost:5001/products/{id}
DELETE https://localhost:5001/products/{id}
```

Roles:

```sh
POST https://localhost:5001/roles
POST https://localhost:5001/roles/{userId}/assign
GET https://localhost:5001/roles
DELETE https://localhost:5001/roles/{roleid}
```

Images:

```sh
POST https://localhost:5001/images
POST https://localhost:5001/images/{productId}/assign
GET https://localhost:5001/images
DELETE https://localhost:5001/images/{id}
```
Athentication:

```sh
POST https://localhost:5001/signup
```
Authentication:

```sh
POST https://localhost:5001/signin
GET https://localhost:5001/users/isavailable
DELETE https://localhost:5001/users/{userId}
```

Cart:

```sh
POST https://localhost:5001/carts
GET https://localhost:5001/carts/{userId}/products
GET https://localhost:5001/carts
DELETE https://localhost:5001/carts/{id}
```


Folder Structure
```sh
C:.
│   api.http
│   appsettings.Development.json
│   appsettings.json
│   backend.csproj
│   Program.cs
│
├───Mapper
│       BaseMapper.cs
│       CartMapper.cs
│       CategoryMapper.cs
│       ImageMapper.cs
│       ProductCategoryExtension.cs
│       ProductMapper.cs
│       UserExtension.cs
│       UserMapper.cs
│
├───Migrations
│       20230321114342_initial_commit.cs
│       20230321114342_initial_commit.Designer.cs
│       AppDBContextModelSnapshot.cs
└───src
    ├───Controllers
    │       ApiController.cs
    │       BaseController.cs
    │       CartController.cs
    │       CategoryController.cs
    │       ImageController.cs
    │       ProductController.cs
    │       RoleController.cs
    │       UserController.cs
    │
    ├───DB
    │       AppDBContext.cs
    │       AppDBContextInterceptor.cs
    │       IdentityConfigExtension.cs
    │       ModelConfiguration.cs
    │
    ├───DTOs
    │   │   BaseDTO.cs
    │   │   DTOAssignImageToPoduct.cs
    │   │   DTOCart.cs
    │   │   DTOCategory.cs
    │   │   DTOCreateUser.cs
    │   │   DTOImage.cs
    │   │   DTOProduct.cs
    │   │   DTOUpdateCart.cs
    │   │   DTOUpdateCategory.cs
    │   │   DTOUpdateImage.cs
    │   │   DTOUpdateProduct.cs
    │   │   DTOUserSignIn.cs
    │   │   DTOUserSignUp.cs
    │   │
    │   ├───DTORequest
    │   │       DTOEmail.cs
    │   │       DTORole.cs
    │   │
    │   └───DTOResponse
    │           DTOCartResponse.cs
    │           DTOCartUpdatedResponse.cs
    │           DTOCategoryImageResponse.cs
    │           DTOCategoryProductResponse.cs
    │           DTOCategoryResponse.cs
    │           DTOCategoryUpdatedResponse.cs
    │           DTOImageResponse.cs
    │           DTOImageUpdatedResponse.cs
    │           DTOProductCategoryResponse.cs
    │           DTOProductResponse.cs
    │           DTOProductUpdatedResponse.cs
    │           DTOUserResponse.cs
    │           DTOUserSignInResponse.cs
    │
    ├───Helpers
    │       ServiceException.cs
    │
    ├───MiddleWare
    │       ErrorHandlerMiddleware.cs
    │
    ├───Models
    │       BaseModel.cs
    │       Cart.cs
    │       Category.cs
    │       Image.cs
    │       Product.cs
    │       Rating.cs
    │       User.cs
    │
    ├───ModelValidation
    │       EnsureMandatoryFieldsActionFilter.cs
    │       User_EnsurePasswordsMatch.cs
    │
    ├───Repository
    │   ├───BaseRepo
    │   │       BaseRepo.cs
    │   │       IBaseRepo.cs
    │   │       ITokenRepo.cs
    │   │
    │   ├───CartRepository
    │   │   │   CartRepo.cs
    │   │   │
    │   │   └───Cart
    │   │           ICartRepo.cs
    │   │
    │   ├───CategoryRepository
    │   │       CategoryRepo.cs
    │   │       ICategoryRepo.cs
    │   │
    │   ├───ImageRepository
    │   │       IImageRepo.cs
    │   │       ImageRepo.cs
    │   │
    │   ├───ProductRepository
    │   │       IProductRepo.cs
    │   │       ProductRepo.cs
    │   │
    │   ├───RoleRepository
    │   │       IRoleRepo.cs
    │   │       RoleRepo.cs
    │   │
    │   └───UserRepository
    │           IUserRepo.cs
    │           UserRepo.cs
    │
    └───Services
        ├───BaseService
        │       BaseService.cs
        │       IBaseService.cs
        │       IUserService.cs
        │
        ├───CartService
        │       CartService.cs
        │       ICartService.cs
        │
        ├───CategoryService
        │       CategoryService.cs
        │       ICategoryService.cs
        │
        ├───ImageService
        │       IImageService.cs
        │       ImageService.cs
        │
        ├───ProductService
        │       IProductService.cs
        │       ProductService.cs
        │
        ├───RoleService
        │       IRoleService.cs
        │       RoleService.cs
        │
        ├───TokenService
        │       ITokenService.cs
        │       TokenService.cs
        │
        └───UserService
                IUserService.cs
                UserService.cs
```


3. You can change .NET Core version to be compatible with your local machine

## Requirements

Below are the steps that you need to finish in order to finish this module

1. Your full stack project should have one git repo to manage both frontend and backend. The shared .git in the root directory is used to push commits to the remote repo. In case you need to deploy frontend and backend to different server, you can inittiate another `.git` folder in each repository. Syntax: `cd frontend` -> `git init` (similar to backend folder). Remember to add `.gitignore` for each folder when you intiate `git` repo.
2. `frontend` folder is for the react frontend. Start with `backend` first before moving on to `frontend`.
3. `backend` should have proper file structure, naming convention, and comply with Rest API.
4. Each topic would have different features. However, the main routes should have CRUD operations, authentication and authorization.
5. You need to deploy the fullstack project, rewrite `README.md` as instructed earlier in the course.

EFCore for database connection
ActionFilterAttribute
AutoMapper

1.Implemented AutoMapper

