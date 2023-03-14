using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CategoryService;

namespace backend.src.Controllers;

public class CategoryController : BaseController<Category, DTOCategory, DTOCategory, DTOCategoryResponse>
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) : base(service)
    {
        _service = service;
    }
}