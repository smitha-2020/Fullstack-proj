using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;

namespace backend.Mapper;

public class CategoryMapper : BaseMapper
{
    public CategoryMapper()
    {
        CreateMap<Category, DTOCategoryResponse>();
        CreateMap<DTOUpdateCategory, Category>();
        CreateMap<DTOCategory, Category>();
        CreateMap<DTOUpdateCategory, DTOCategoryResponse>();
        CreateMap<DTOCategoryResponse, Category>();
        CreateMap<Category, DTOCategoryProductResponse>();
    }
}