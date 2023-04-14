using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

//[Authorize(Roles = "Admin")]
public class ProductController : BaseController<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse, DTOProductUpdatedResponse>
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService service, ILogger<ProductController> logger) : base(service)
    {
        _service = service;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpGet]
    public override async Task<ActionResult<IEnumerable<DTOProductResponse>?>> GetAll([FromQuery] QueryOptions? options)
    {
        return Ok(await _service.GetAllAsync(options!));
    }

    [AllowAnonymous]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<DTOProductResponse>?>> GetAllProducts()
    {
        return Ok(await _service.GetAllProductsAsync());
    }

    [HttpGet("{id}/productimages")]
    public async Task<ActionResult> GetProductImages(int id)
    {
        return Ok(await _service.GetProductImages(id));
    }

    [HttpPut("{id:int}")]
    public override async Task<ActionResult> Update(int id, DTOUpdateProduct item)
    {
        return Ok(await _service.UpdateAsync(id, item));
    }
}