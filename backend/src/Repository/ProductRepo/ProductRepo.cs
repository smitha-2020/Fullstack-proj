using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.ProductRepo;

public class ProductRepo : BaseRepo<Product>, IProductRepo
{
    public ProductRepo(AppDBContext dbcontext) : base(dbcontext)
    {
    }
}