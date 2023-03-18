using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.Repository.CartRepository;
using backend.src.Services.BaseService;

namespace backend.src.Services.CartService;

public class CartService : BaseService<Cart, DTOCart, DTOUpdateCart, DTOCartResponse, DTOCartUpdatedResponse>, ICartService
{
    public CartService(ICartRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}