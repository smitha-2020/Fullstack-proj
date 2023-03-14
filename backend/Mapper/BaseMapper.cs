using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;

namespace backend;

public class BaseMapper : Profile
{
    public BaseMapper()
    {
        CreateMap<Category, DTOCategoryResponse>();
        CreateMap<DTOCategory, Category>();

        CreateMap<Product, DTOProductResponse>();
    }
}