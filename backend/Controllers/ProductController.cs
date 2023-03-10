using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

public class ProductController : DbCRUDController<Product, DTOProduct>
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;
    public ProductController(IProductService service, ILogger<ProductController> logger) : base(service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public override async Task<ICollection<Product>?> GetAll()
    {
        ICollection<Product> _products = new List<Product>();
        var products = await _service.GetAllAsync();
        if (products is null)
        {
            return null;
        }
        foreach (var product in products)
        {
            _products.Add(Product.ConvertToDTO(product));
        }
        return _products;
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<Product?>> Get(int id)
    {
        var data = await _service.GetAsync(id);
        if (data is null)
        {
            return NotFound("Item is not found");
        }
        return Product.ConvertToDTO(data);
    }
}