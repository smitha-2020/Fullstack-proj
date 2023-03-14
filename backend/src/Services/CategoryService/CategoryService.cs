using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;

namespace backend.src.Services.CategoryService;

public class CategoryService : BaseService<Category, DTOCategory, DTOCategory, DTOCategoryResponse>, ICategoryService
{
    public CategoryService(IBaseRepo<Category> repo, IMapper mapper) : base(repo, mapper)
    {
    }
}