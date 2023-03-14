using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Services;

public interface ICategoryService : ICRUDService<Category, DTOCategory, DTOCategoryResponse>
{
    Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}