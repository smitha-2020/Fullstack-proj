using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ProductRepository;
using backend.src.DTOs.DTOResponse;

namespace backend.src.Services.ProductService;

public class ProductService : BaseService<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse,DTOProductUpdatedResponse>, IProductService
{
    public ProductService(IProductRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}