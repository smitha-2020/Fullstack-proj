using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.CategoryRepo;

public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
{
    public CategoryRepo(AppDBContext dbcontext) : base(dbcontext)
    {
    }
}