using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;
using backend.src.Services.ImageService;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

public class ImageController : BaseController<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>
{
    private readonly IImageService _service;

    public ImageController(IImageService service) : base(service)
    {
        _service = service;
    }   
}