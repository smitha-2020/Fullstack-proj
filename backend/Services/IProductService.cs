using backend.Models;
using backend.DTOs;

namespace backend.Services;

public interface IProductService : ICRUDService<Product, DTOProduct>
{
  // CURD Operations + Any new Operations
  Task<ICollection<Product>> GetAllProductsByCostAsc();
}