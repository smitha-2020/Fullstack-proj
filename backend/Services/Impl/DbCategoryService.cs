using Microsoft.EntityFrameworkCore;
using backend.DB;
using backend.DTOs;
using backend.Models;
using backend.Services.Impl;
using backend.Services;

namespace backend.Services.Impl;

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