using Microsoft.EntityFrameworkCore;
using backend.src.DB;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services;

namespace backend.src.Services;

public class DbCategoryService : DbCrudService<Category, DTOCategory, DTOCategoryResponse>, ICategoryService
{
    private readonly AppDBContext _dbContext;
    public DbCategoryService(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Category>> GetByNameOrder()
    {
        return await Task.Run(() => _dbContext.Categorys.OrderBy(x => x.Id).ToList());
    }
}