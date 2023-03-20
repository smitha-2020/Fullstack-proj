using backend.src.Models;
using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Services.BaseService;


namespace backend.src.Services.ImageService;

public interface IImageService : IBaseService<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>
{
    //Task<ICollection<DTOCategoryProductResponse>> GetAllProductsByCategory(int categoryId);
    //Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}