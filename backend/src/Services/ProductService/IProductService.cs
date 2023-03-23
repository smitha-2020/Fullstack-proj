using backend.src.Models;
using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;

namespace backend.src.Services.ProductService;

public interface IProductService : IBaseService<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse,DTOProductUpdatedResponse>
{
    Task<IEnumerable<DTOProductResponse>?> GetAllAsync();
    
    //Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}