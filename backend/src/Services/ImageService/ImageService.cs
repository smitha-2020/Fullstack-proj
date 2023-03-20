using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ImageRepository;
using backend.src.Repository.ProductRepository;

namespace backend.src.Services.ImageService;

public class ImageService : BaseService<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>, IImageService
{
    private readonly IImageRepo _repo;
    private readonly ILogger<ImageService> _logger;
    private readonly IProductRepo _productRepo;
    public ImageService(IImageRepo repo, IProductRepo productRepo, ILogger<ImageService> logger, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _productRepo = productRepo;
        _logger = logger;
    }

    public async Task<int> AssignImagesToProduct(int productId, ICollection<int> images)
    {
        var validProduct = await _productRepo.GetByIdAsync(productId);
        if (validProduct is null)
        {
            return -1;
        }
        var validImagesCollection = await _repo.GetAllDataAsync();
        if (validImagesCollection is null)
        {
            return -1;
        }
        var count = await _repo.AssignImagesToProduct(validProduct, validImagesCollection);
        return count;
    }
}