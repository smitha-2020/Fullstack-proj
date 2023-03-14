using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services;

namespace backend.src.Controllers;

public class CategoryController : DbCRUDController<Category, DTOCategory,DTOCategoryResponse>
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) : base(service)
    {
        _service = service;
    }
}