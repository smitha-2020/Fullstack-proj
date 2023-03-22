using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.ProductRepository;

public class ProductRepo : BaseRepo<Product>, IProductRepo
{
    public ProductRepo(AppDBContext dbcontext) : base(dbcontext)
    {
        DbSet = _dbcontext.Set<Product>();
    }

    public override async Task<IEnumerable<Product>?> GetAllAsync(QueryOptions options)
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

    public async Task<IEnumerable<Product>> GetBySearch(string searchText)
    {
        return await Task.Run(()=> DbSet.Where(e => e.Title.Contains(searchText)).ToArray());
    }
}