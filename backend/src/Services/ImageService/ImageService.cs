using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.ImageRepository;

namespace backend.src.Services.ImageService;

public class ImageService : BaseService<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>, IImageService
{
    public ImageService(IImageRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}