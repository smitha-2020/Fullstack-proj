using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ProductRepository;
using backend.src.DTOs.DTOResponse;
using backend.src.Repository.BaseRepo;

namespace backend.src.Services.ProductService;

public class ProductService : BaseService<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse, DTOProductUpdatedResponse>, IProductService
{
    private readonly IProductRepo _repo;
    private readonly IMapper _mapper;
    public ProductService(IProductRepo repo, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DTOProductResponse>?> GetAllAsync()
    {
        var result = await _repo.GetAllAsync();
        if (result is null)
        {
            return null;
        }
        return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProductResponse>>(result);
    }

    public async override Task<IEnumerable<DTOProductResponse>?> GetAllAsync(QueryOptions? options)
    {

        var result = await _repo.GetAllAsync();
        if (options is null)
        {
            return null;
        }
        if (options.Search is not null && options.Search.Length > 0)
        {
            result = await _repo.GetBySearch(options.Search.Trim());
        }
        if (result is null)
        {
            return null;
        }
        if (options.SortByProperty == "Title")
        {
            result = await _repo.SortBy(options, result);
        }
        if (options.SortByProperty == "Price")
        {
            result = await _repo.SortByPrice(options, result);
        }
        if (result is null)
        {
            return null;
        }
        result=result.Skip(options.Page*options.CardsPerPage).Take(options.CardsPerPage);
        return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProductResponse>>(result);
    }
}