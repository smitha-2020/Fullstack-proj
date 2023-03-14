using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Services;

public interface IProductService : ICRUDService<Product, DTOProduct, DTOProductResponse>
{
  // CURD Operations + Any new Operations
  Task<ICollection<Product>> GetAllProductsByCostAsc();
}