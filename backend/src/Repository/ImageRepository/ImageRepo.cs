using backend.src.DB;
using backend.src.Models;
using backend.src.Repository.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repository.ImageRepository;

public class ImageRepo : BaseRepo<Image>, IImageRepo
{
    public ImageRepo(AppDBContext dbcontext) : base(dbcontext)
    {
        
    }
}