using backend.src.Models;
using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Services.BaseService;


namespace backend.src.Services.CategoryService;

public interface ICategoryService : IBaseService<Category, DTOCategory, DTOUpdateCategory, DTOCategoryResponse, DTOCategoryUpdatedResponse>
{
    Task<ICollection<DTOCategoryProductResponse>> GetAllProductsByCategory(int categoryId);
    //Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}