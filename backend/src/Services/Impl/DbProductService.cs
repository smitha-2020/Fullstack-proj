using Microsoft.EntityFrameworkCore;
using backend.src.DB;
using backend.src.DTOs;
using backend.src.Models;


namespace backend.src.Services;

public class DbProductService : DbCrudService<Product, DTOProduct, DTOProductResponse>, IProductService
{
  private readonly AppDBContext _dbContext;
  public DbProductService(AppDBContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public override async Task<Product?> GetAsync(int id)
  {
    var selectedData = await Task.Run(() => GetAllAsync().Result!.SingleOrDefault(x => x.Id == id));
    return selectedData;
  }
  
  public async Task<ICollection<Product>> GetAllProductsByCostAsc()
  {
    return await Task.Run(() => _dbContext.Products.AsNoTracking().Include(x => x.Category).OrderBy(x => x.Price).ToList());
  }

}