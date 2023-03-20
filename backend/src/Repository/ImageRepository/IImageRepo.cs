using backend.src.Models;
using backend.src.Repository.BaseRepo;

namespace backend.src.Repository.ImageRepository;

public interface IImageRepo: IBaseRepo<Image>
{
   Task<int> AssignImagesToProduct(Product product, ICollection<Image> images);
}