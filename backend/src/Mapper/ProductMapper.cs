using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;

namespace backend.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, DTOProductResponse>();
        CreateMap<Category, DTOCategoryResponse>();
    }
}