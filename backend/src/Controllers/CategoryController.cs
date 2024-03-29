using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend.src.Controllers;

public class CategoryController : BaseController<Category, DTOCategory, DTOUpdateCategory, DTOCategoryResponse, DTOCategoryUpdatedResponse>
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) : base(service)
    {
        _service = service;
    }
    
    [AllowAnonymous]
    [HttpGet("{id}/products")]
    public async Task<ActionResult<ICollection<DTOCategoryImageResponse>>> GetAllProductsByCategory(int id)
    {
        return Ok(await _service.GetAllProductsByCategory(id));
    }
}