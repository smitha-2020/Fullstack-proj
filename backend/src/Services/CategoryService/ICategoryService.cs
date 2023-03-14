using backend.src.Models;
using backend.src.DTOs;
using backend.src.Services.BaseService;

namespace backend.src.Services.CategoryService;

public interface ICategoryService : IBaseService<Category, DTOCategory, DTOCategory, DTOCategoryResponse>
{
    //Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}