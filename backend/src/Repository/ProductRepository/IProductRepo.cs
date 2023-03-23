using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.ProductRepository;

public interface IProductRepo : IBaseRepo<Product>
{
    Task<IEnumerable<Product>> GetBySearch(string searchText);
     Task<IEnumerable<Product>?> GetAllAsync();
    Task<IEnumerable<Product>> SortBy(QueryOptions order, IEnumerable<Product> query);
    Task<IEnumerable<Product>> SortByPrice(QueryOptions order, IEnumerable<Product> query);
    Task<IEnumerable<Product>> SortByProperty(string property, SortBy order);
    Task<IEnumerable<Product>?> GetAllAsync(QueryOptions options, IEnumerable<Product> result);
}