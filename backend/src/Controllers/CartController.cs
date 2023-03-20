using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CartService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

public class CartController : BaseController<Cart, DTOCart, DTOUpdateCart, DTOCartResponse, DTOCartUpdatedResponse>
{
    private readonly ICartService _service;

    public CartController(ICartService service) : base(service)
    {
        _service = service;
    }

    //[HttpGet("carts/{id}")]
    [HttpGet("{id:Guid}/products")]
    public async Task<ActionResult<DTOCartResponse?>> GetCartData(Guid id)
    {
        return Ok(await _service.GetByUserId(id));
    }    
}