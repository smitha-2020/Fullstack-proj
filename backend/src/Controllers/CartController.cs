using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CartService;

namespace backend.src.Controllers;

public class CartController : BaseController<Cart, DTOCart, DTOUpdateCart, DTOCartResponse, DTOCartUpdatedResponse>
{
    private readonly ICartService _service;

    public CartController(ICartService service) : base(service)
    {
        _service = service;
    }
}