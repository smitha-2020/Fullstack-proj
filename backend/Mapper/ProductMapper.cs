using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, DTOProductResponse>();
        CreateMap<Category, DTOCategoryResponse>();
    }
}