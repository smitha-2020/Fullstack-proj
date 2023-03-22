using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.ProductRepository;

public interface IProductRepo: IBaseRepo<Product>
{
    Task<IEnumerable<Product>> GetBySearch(string searchText); 
}