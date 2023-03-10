using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

public class CategoryController : DbCRUDController<Category, DTOCategory>
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) : base(service)
    {
        _service = service;
    }
}