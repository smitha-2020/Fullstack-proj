namespace backend.Services;
using backend.Models;
using backend.DTOs;

public interface ICRUDService<TModel, TDto> 
where TModel : BaseModel, new() 
where TDto:BaseDTO<TModel>
{
  // CURD Operations
  Task<TModel?> CreateAsync(TDto request);
  Task<TModel?> GetAsync(int id);
  Task<TModel?> UpdateAsync(int id, TDto request);
  Task<bool> DeleteAsync(int id);
  Task<ICollection<TModel>> GetAllAsync();
}