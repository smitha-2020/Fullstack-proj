using backend.src.Repository;
using backend.src.Repository.BaseRepo;
using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Repository.CartRepository;

public interface ICartRepo : IBaseRepo<Cart>
{
    Task<ICollection<Cart>?> GetByUserId(Guid userId);
    Task<ICollection<Cart>?> IsAlreadyAvailable(int id);
}