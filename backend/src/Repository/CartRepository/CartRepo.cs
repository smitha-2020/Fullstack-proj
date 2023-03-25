using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.DB;
using backend.src.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.CartRepository;

public class CartRepo : BaseRepo<Cart>, ICartRepo
{
    protected DbSet<Cart> DbData { get; set; } = null!;
    public CartRepo(AppDBContext dbcontext) : base(dbcontext)
    {
        DbData = _dbcontext.Set<Cart>();
    }

    public async Task<ICollection<Cart>?> GetByUserId(Guid userId)
    {
        return await DbData.Where(e => e.UserId == userId).ToListAsync();
    }

    public async Task<ICollection<Cart>?> IsAlreadyAvailable(int id)
    {
        var cartDetails = await DbData.Where(e => e.ProductId == id).ToListAsync();
        return cartDetails;
    }
}
