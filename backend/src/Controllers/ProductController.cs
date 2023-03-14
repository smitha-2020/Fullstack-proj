using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace backend.src.Controllers;

public class ProductController : DbCRUDController<Product, DTOProduct, DTOProductResponse>
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;
    public readonly IMapper _mapper;
    public ProductController(IProductService service, ILogger<ProductController> logger, IMapper mapper) : base(service)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public override async Task<ICollection<DTOProductResponse>?> GetAll()
    {
        ICollection<DTOProductResponse> _products = new List<DTOProductResponse>();
        var products = await _service.GetAllAsync();
        if (products is null)
        {
            return null;
        }
        foreach (var product in products)
        {
            var _mappedUser = _mapper.Map<DTOProductResponse>(product);
            _products.Add(_mappedUser);
        }
        return _products;
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<DTOProductResponse?>> Get(int id)
    {
        var data = await _service.GetAsync(id);
        if (data is null)
        {
            return NotFound("Item is not found");
        }
        return _mapper.Map<DTOProductResponse>(data);
    }
}