using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ImageRepository;
using backend.src.Repository.ProductRepository;
using backend.src.Helpers;

namespace backend.src.Services.ImageService;

public class ImageService : BaseService<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>, IImageService
{
    private readonly IImageRepo _repo;
    private readonly ILogger<ImageService> _logger;
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;
    public ImageService(IImageRepo repo, IProductRepo productRepo, ILogger<ImageService> logger, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _productRepo = productRepo;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> AssignImagesToProduct(int productId, ICollection<int> images)
    {
        var validProduct = await _productRepo.GetByIdAsync(productId);
        if (validProduct is null)
        {
            throw ServiceException.NotFound("Item with ID does not exist");
            //return -1;
        }
        var validImagesCollection = await _repo.GetAllDataAsync();
        if (validImagesCollection is null)
        {
            throw ServiceException.NotFound("Collection of Items to be assigned does not exist");
            //return -1;
        }
        var validImagObj = validImagesCollection.Where(e => images.Contains(e.Id)).ToArray();
        if (validImagObj.Length < 3)
        {
            throw ServiceException.NotFound("Collection must contain atleast 3 valid images");
            //return -1;
        }
        var count = await _repo.AssignImagesToProduct(validProduct, validImagObj);
        return count;
    }
}