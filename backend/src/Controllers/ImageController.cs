using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;
using backend.src.Services.ImageService;
using backend.src.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

public class ImageController : BaseController<Image, DTOImage, DTOUpdateImage, DTOImageResponse, DTOImageUpdatedResponse>
{
    private readonly IImageService _service;
    private readonly IProductService _prodService;
    private readonly ILogger<ImageController> _logger;

    public ImageController(IImageService service, IProductService prodService, ILogger<ImageController> logger) : base(service)
    {
        _service = service;
        _prodService = prodService;
        _logger = logger;
    }

    [HttpPost("{id}/assign")]
    public async Task<IActionResult> AssignImagesToProduct(int id, DTOAssignImageToPoduct request)
    {
        return Ok(new {Message = await _service.AssignImagesToProduct(id, request.images) + $"roles assigned to the user ${id}"});
    }
}