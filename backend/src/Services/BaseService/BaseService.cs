using AutoMapper;
using backend.src.Repository.BaseRepo;

namespace backend.src.Services.BaseService;

public class BaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> : IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse>
{
    private readonly IBaseRepo<TModel> _repo;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepo<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<TResponse?> CreateAsync(TCreateDto create)
    {
        var entity = _mapper.Map<TCreateDto, TModel>(create);
        var result = await _repo.CreateOneAsync(entity);
        if (result is null)
        {
            throw new Exception("Item Cannot be Created");
        }
        var newResult = _mapper.Map<TModel, TResponse>(result);
        return newResult;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repo.DeleteOneAsync(id);
    }

    public async Task<IEnumerable<TResponse>?> GetAllAsync(QueryOptions options)
    {
        var dataArr = await _repo.GetAllAsync(options);
        return dataArr is null ? null : _mapper.Map<IEnumerable<TModel>, IEnumerable<TResponse>>(dataArr);
    }

    public async Task<TResponse?> GetAsync(int id)
    {
        var singleData = await _repo.GetByIdAsync(id);
        if (singleData is null)
        {
            throw new Exception("ID is not found");
        }
        return _mapper.Map<TModel, TResponse>(singleData);
    }

    public async Task<TResponse?> UpdateAsync(int id, TUpdateDto update)
    {
        // var entity = await _repo.GetByIdAsync(id);
        // if (entity is null)
        // {
        //     throw new ArgumentNullException("entity Reference rror!!");
        // }

        // var newData = _mapper.Map<TUpdateDto, TModel>(update);

        // if (newData is null)
        // {
        //     throw new ArgumentNullException("newData Reference rror!!");
        // }

        // var updatedData = await _repo.UpdateOneAsync(id, _mapper.Map<TUpdateDto, TModel>(update));
        // if (updatedData is null)
        // {
        //     throw new ArgumentNullException("Null Reference rror!!");
        // }
        // return _mapper.Map<TModel, TResponse>(updatedData);

        var entity = _mapper.Map<TUpdateDto, TModel>(update);
        if (entity is null)
        {
            throw new Exception("No Entity to be updated");
        }
        var updatedData = await _repo.UpdateOneAsync(id, entity);
        if (updatedData is null)
        {
            throw new Exception("Item cannot be updated");
        }
        return _mapper.Map<TModel, TResponse>(updatedData);
    }
}