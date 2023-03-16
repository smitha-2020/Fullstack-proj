using backend.src.Models;
using backend.src.Repository.BaseRepo;
using backend.src.DB;

namespace backend.src.Repository;

public class CartRepo : BaseRepo<Cart>, ICartRepo
{
    public CartRepo(AppDBContext dbcontext) : base(dbcontext)
    {
    }
}
