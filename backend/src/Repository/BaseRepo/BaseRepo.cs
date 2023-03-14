using backend.src.Models;
using backend.src.DB;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.BaseRepo;

public class BaseRepo<TModel> : IBaseRepo<TModel>
where TModel : BaseModel
{
    private readonly AppDBContext _dbcontext;

    public BaseRepo(AppDBContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<TModel?> CreateOneAsync(TModel create)
    {
        await _dbcontext.Set<TModel>().AddAsync(create);
        return create;
    }

    public async Task<bool> DeleteOneAsync(int id)
    {
        var foundItem = await GetByIdAsync(id);
        var deletedItem = foundItem is null ? null : _dbcontext.Remove(foundItem);
        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TModel>?> GetAllAsync(QueryOptions options)
    {
        var query = _dbcontext.Set<TModel>();
        if (options.SortByProperty.Trim().Length > 0)
        {
            if (query.GetType().GetProperty(options.SortByProperty) != null)
            {
                query.OrderBy(e => e.GetType().GetProperty(options.SortByProperty));
            }
        }
        query.Skip(options.Page).Take(options.CardsPerPage);
        return await query.ToArrayAsync();
    }

    public async Task<TModel?> GetByIdAsync(int id)
    {
        return await _dbcontext.Set<TModel>().FindAsync(id);
    }

    public async Task<TModel?> UpdateOneAsync(int id, TModel update)
    {
        var entity = update;
        await _dbcontext.SaveChangesAsync();
        return await GetByIdAsync(id);
    }
}