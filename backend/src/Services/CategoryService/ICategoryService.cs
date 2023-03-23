using backend.src.Models;
using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Services.BaseService;


namespace backend.src.Services.CategoryService;

public interface ICategoryService : IBaseService<Category, DTOCategory, DTOUpdateCategory, DTOCategoryResponse, DTOCategoryUpdatedResponse>
{
    Task<ICollection<DTOCategoryImageResponse>> GetAllProductsByCategory(int categoryId);
}