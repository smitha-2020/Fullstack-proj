using backend.src.Models;
using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Services.BaseService;


namespace backend.src.Services.CartService;

public interface ICartService : IBaseService<Cart, DTOCart, DTOUpdateCart, DTOCartResponse, DTOCartUpdatedResponse>
{
    Task<ICollection<DTOCartResponse>?> GetByUserId(Guid userId);
}