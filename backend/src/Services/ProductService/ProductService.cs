using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ProductRepository;
using backend.src.DTOs.DTOResponse;
using backend.src.Repository.BaseRepo;

namespace backend.src.Services.ProductService;

public class ProductService : BaseService<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse,DTOProductUpdatedResponse>, IProductService
{
    private readonly IProductRepo _repo;
    private readonly IMapper _mapper;
    public ProductService(IProductRepo repo, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async override Task<IEnumerable<DTOProductResponse>?> GetAllAsync(QueryOptions options)
    {
        var result = await _repo.GetAllAsync(options);
        if(result is null){return null;}
        if(options.Search!=null){
            await _repo.GetBySearch(options.Search.Trim());
        }
        return _mapper.Map<IEnumerable<Product>,IEnumerable<DTOProductResponse>>(result);
    }
}