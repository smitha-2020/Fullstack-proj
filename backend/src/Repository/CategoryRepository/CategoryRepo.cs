using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.CategoryRepository;

public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
{
    private DbSet<Category> DbDataCategory { get; set; } = null!;
    
    public CategoryRepo(AppDBContext dbcontext) : base(dbcontext)
    {
        DbDataCategory = _dbcontext.Set<Category>();
    }

    public async Task<ICollection<Category>> GetAllProductsByCategory(int categoryId)
    {
        Console.WriteLine(DbDataCategory.GetType());
        return await DbDataCategory.Where(e => e.Id == categoryId).ToArrayAsync();
    }
}