using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DB;
using backend.DTOs;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class DbCrudService<TModel, TDto, TResponse> : ICRUDService<TModel, TDto, TResponse>
where TModel : BaseModel, new()
where TDto : BaseDTO<TModel>
{
    private readonly AppDBContext _dbContext;
    public DbCrudService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TModel?> CreateAsync(TDto request)
    {
        var item = new TModel();
        request.UpdateModel(item);
        _dbContext.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetAsync(id);
        if (item is null)
        {
            return false;
        }
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public virtual async Task<TModel?> GetAsync(int id)
    {
        return await _dbContext.Set<TModel>().FindAsync(id);
    }

    // public virtual async Task<ICollection<TModel>> GetAllAsync()
    // {
    //     return await _dbContext.Set<TModel>().AsNoTracking().ToListAsync();
    // }

    public async Task<TModel?> UpdateAsync(int id, TDto request)
    {
        var item = await GetAsync(id);
        if (item is null)
        {
            return null;
        }
        request.UpdateModel(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public virtual async Task<ICollection<TModel>?> GetAllAsync()
    {
        return await _dbContext.Set<TModel>().AsNoTracking().ToListAsync();
    }
}