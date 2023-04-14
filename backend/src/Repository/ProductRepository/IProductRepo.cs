using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.ProductRepository;

public interface IProductRepo : IBaseRepo<Product>
{
    Task<IEnumerable<Product>> GetBySearch(string searchText);
    Task<IEnumerable<Product>?> GetAllAsync();
    Task<IEnumerable<Product>?> GetAllProductsAsync();
    Task<IEnumerable<Product>> SortByOrder(SortBy order, IEnumerable<Product> query);
    Task<IEnumerable<Product>> SortByPrice(SortBy order, IEnumerable<Product> query);
    Task<IEnumerable<Product>> SortByProperty(string property, SortBy order);
    Task<IEnumerable<Product>?> GetAllAsync(QueryOptions options, IEnumerable<Product> result);
    Task<IEnumerable<Image>?> GetProductImages(int id);
}