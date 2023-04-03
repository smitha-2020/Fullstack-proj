using backend.src.DTOs.DTOResponse;
using backend.src.DTOs;
using backend.src.Models;
using AutoMapper;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;
using backend.src.Repository.CategoryRepository;
using backend.src.Helpers;

namespace backend.src.Services.CategoryService;

public class CategoryService : BaseService<Category, DTOCategory, DTOUpdateCategory, DTOCategoryResponse, DTOCategoryUpdatedResponse>, ICategoryService
{
    private readonly ICategoryRepo _repo;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepo repo, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ICollection<DTOCategoryImageResponse>> GetAllProductsByCategory(int categoryId)
    {
        var validCategory = await _repo.GetByIdAsync(categoryId);
        if(validCategory is null){
            throw ServiceException.NotFound("Item with ID does not Exist");
        }
        var categoryProducts = await _repo.GetAllProductsByCategory(categoryId);
        if (categoryProducts is null)
        {
            throw ServiceException.NotFound("Item Could not be found");
        }
        return _mapper.Map<ICollection<Category>, ICollection<DTOCategoryImageResponse>>(categoryProducts);
    }
}