using backend.Models;
using backend.DTOs;

namespace backend.Services;

public interface ICategoryService : ICRUDService<Category, DTOCategory, DTOCategoryResponse>
{
    Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}