using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.CategoryRepository;

public interface ICategoryRepo: IBaseRepo<Category>
{
    Task<ICollection<Category>> GetAllProductsByCategory(int categoryId);
}