using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;
using backend.src.Repository.CategoryRepository;

namespace backend.src.Services.CategoryService;

public class CategoryService : BaseService<Category, DTOCategory, DTOUpdateCategory, DTOCategoryResponse, DTOCategoryUpdatedResponse>, ICategoryService
{
    public CategoryService(ICategoryRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}