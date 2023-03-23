using backend.src.Repository.BaseRepo;

namespace backend.src.Services.BaseService;

public interface IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse>
{
    // CURD Operations
    Task<TResponse?> CreateAsync(TCreateDto request);
    Task<TResponse?> GetAsync(int id);
    Task<TResponse?> UpdateAsync(int id, TUpdateDto request);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<TResponse>?> GetAllAsync(QueryOptions options);
}