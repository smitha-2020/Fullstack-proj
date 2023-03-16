using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.DB;

namespace backend.src.Repository;

public class CartItemRepo : BaseRepo<CartItem>, ICartItem
{
    public CartItemRepo(AppDBContext dbcontext) : base(dbcontext)
    {
    }
}
