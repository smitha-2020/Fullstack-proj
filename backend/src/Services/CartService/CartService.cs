using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.Repository.CartRepository;
using backend.src.Services.BaseService;

namespace backend.src.Services.CartService;

public class CartService : BaseService<Cart, DTOCart, DTOUpdateCart, DTOCartResponse, DTOCartUpdatedResponse>, ICartService
{
    private readonly ICartRepo _repo;
    private readonly IMapper _mapper;
    public CartService(ICartRepo repo, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ICollection<DTOCartResponse>?> GetByUserId(Guid userId)
    {
        var cartData = await _repo.GetByUserId(userId);
        if (cartData is null)
        {
            return null;
        }
        return _mapper.Map<ICollection<Cart>, ICollection<DTOCartResponse>>(cartData);
    }

    public async Task<bool> IsAvailableeInCart(int id)
    {
        var cartData = await _repo.IsAlreadyRegistered(id);
        if (cartData is not null && cartData.Count > 0)
        {
            return true;
        }
        return false;
    }
}