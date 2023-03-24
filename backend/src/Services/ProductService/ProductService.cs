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
        SortBy order;
        var result = await _repo.GetAllAsync();
        if (options is null && result is not null)
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProductResponse>>(result);
        }
        if (options is not null)
        {
            if (options.Search is not null && options.Search.Length > 0)
            {
                result = await _repo.GetBySearch(options.Search.Trim());
            }
            if (result is null)
            {
                return null;
            }
            if (Enum.TryParse<SortBy>(options.Sort!.ToUpper(), out order))
            {
                if (options.SortByProperty == "Title")
                {
                    result = await _repo.SortByOrder(order, result);
                }
                if (options.SortByProperty == "Price")
                {
                    Console.WriteLine(options.Sort);
                    result = await _repo.SortByPrice(order, result);
                }
            }
            result = result.Skip(options.Page * options.CardsPerPage).Take(options.CardsPerPage);
        }
        if (result is null)
        {
            return null;
        }
        return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProductResponse>>(result);
    }

    public async Task<IEnumerable<DTOProductResponse>?> GetAllProductsAsync()
    {
        var result = await _repo.GetAllProductsAsync();
        if (result is null)
        {
            return null;
        }
        return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProductResponse>>(result);
    }
}