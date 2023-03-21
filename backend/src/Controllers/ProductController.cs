using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;
using backend.src.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

public class ProductController : BaseController<Product, DTOProduct, DTOUpdateProduct, DTOProductResponse, DTOProductUpdatedResponse>
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService service, ILogger<ProductController> logger) : base(service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPut("{id:int}")]
    public override async Task<ActionResult> Update(int id, DTOUpdateProduct item)
    {
        return Ok(await _service.UpdateAsync(id, item));
    }
}