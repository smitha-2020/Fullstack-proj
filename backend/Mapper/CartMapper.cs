
using backend.src.DTOs;
using backend.src.Models;

namespace backend.Mapper;

public class CartMapper : BaseMapper
{
    public CartMapper()
    {
        CreateMap<DTOCart, Cart>();
        CreateMap<Cart, DTOCartResponse>();
    }
}