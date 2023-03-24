using System.Reflection;
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
        var query = DbSet.AsNoTracking().AsQueryable();
    }

    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        var query = DbSet.AsNoTracking().AsQueryable();
        return await query.ToArrayAsync();
    }

    public async Task<IEnumerable<Product>?> GetAllAsync(QueryOptions options, IEnumerable<Product> query)
    {
        if (options.SortByProperty is not null && options.SortByProperty.Trim().Length > 0)
        {
            if (query.GetType().GetProperty(options.SortByProperty) is not null)
            {
                query.OrderByDescending(e => e.GetType().GetProperty(options.SortByProperty));
            }
            else
            {
                query.OrderByDescending(e => e.GetType().GetProperty(options.SortByProperty));
            }
        }
        query.Skip(options.Page).Take(options.CardsPerPage);
        return await Task.Run(() => query);
    }

    public async Task<IEnumerable<Product>?> GetAllProductsAsync()
    {
       return await Task.Run(() => _dbcontext.Products.OrderBy(e => e.Title).ToArray());
    }

    public async Task<IEnumerable<Product>> GetBySearch(string searchText)
    {
        return await Task.Run(() => DbSet.Where(e => e.Title.ToLower().Contains(searchText.ToLower())).ToArray());
    }

    public async Task<IEnumerable<Product>> SortByOrder(SortBy order, IEnumerable<Product> query)
    {
        if (order == SortBy.DESC)
        {
            return await Task.Run(() => query.OrderByDescending(e => e.Title).ToArray());
        }
        return await Task.Run(() => query.OrderBy(e => e.Title).ToArray());
    }

    public async Task<IEnumerable<Product>> SortByPrice(SortBy order, IEnumerable<Product> query)
    {
        if (order == SortBy.DESC)
        {
            Console.WriteLine("Price");
            return await Task.Run(() => query.OrderByDescending(e => e.Price).ToArray());
        }
        return await Task.Run(() => query.OrderBy(e => e.Price).ToArray());
    }

    public async Task<IEnumerable<Product>> SortByProperty(string property, SortBy order)
    {
        var query = DbSet.AsQueryable();
        if (query.GetType().GetProperty(property) != null)
        {
            query.OrderBy(e => e.GetType().GetProperty(property));
        }
        return await Task.Run(() => query);
    }
}