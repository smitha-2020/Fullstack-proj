using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.ImageRepository;

public class ImageRepo : BaseRepo<Image>, IImageRepo
{
    private readonly ILogger<ImageRepo> _logger;
    public ImageRepo(AppDBContext dbcontext,ILogger<ImageRepo> logger) : base(dbcontext)
    {
        _logger = logger;
    }

    public async Task<int> AssignImagesToProduct(Product product, ICollection<Image> images)
    {
        foreach (var imageObj in images)
        { 
            product.ImageLink.Add(imageObj);
        }
        await _dbcontext.SaveChangesAsync();
        return await Task.Run(()=> images.Count());
    }
}