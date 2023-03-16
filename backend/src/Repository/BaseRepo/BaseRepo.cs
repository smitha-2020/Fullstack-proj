using backend.src.Models;
using backend.src.DB;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.BaseRepo;

public class BaseRepo<TModel> : IBaseRepo<TModel>
where TModel : BaseModel
{
    protected readonly AppDBContext _dbcontext;
    protected DbSet<TModel> DbSet { get; set; }

    public BaseRepo(AppDBContext dbcontext)
    {
        _dbcontext = dbcontext;
        if (_dbcontext is null)
        {
            throw new ArgumentNullException("DBContext is null");
        }
        DbSet = _dbcontext.Set<TModel>();
    }

    public async Task<TModel?> CreateOneAsync(TModel create)
    {
        await DbSet.AddAsync(create);
        await _dbcontext.SaveChangesAsync();
        //want to return thr created obj
        return await GetByIdAsync(create.Id);
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
        var query = DbSet.AsNoTracking().AsQueryable();
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
        return await DbSet.FindAsync(id);
    }

    public async Task<TModel?> UpdateOneAsync(int id, TModel update)
    {
        // dbEntityEntry = _dbcontext.Entry(update);
        // if (dbEntityEntry.State == EntityState.Detached)
        // {
        //     DbSet.Attach(upate);
        // }
        // dbEntityEntry.State = EntityState.Modified;
        var entity = await GetByIdAsync(id);
        // if (entity is null)
        // {
        //     return null;
        // }
        entity = update;
        //_dbcontext.Entry(update).State = EntityState.Modified;
        //DbSet.Add(entity);
        //_dbcontext.Entry(entity).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
        return await GetByIdAsync(update.Id);
    }
}