using Microsoft.AspNetCore.Mvc;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;

namespace backend.src.Controllers;

public abstract class BaseController<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> : ApiController
{
    private readonly IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> _service;
    public BaseController(IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TResponse>?>> GetAll([FromQuery] QueryOptions options)
    {
        return Ok(await _service.GetAllAsync(options));
    }

    [HttpPost]
    public async Task<IActionResult> Create(TCreateDto item)
    {
        return Ok(await _service.CreateAsync(item));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TResponse?>> Get(int id)
    {
        return Ok(await _service.GetAsync(id));
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult> Update(int id, TUpdateDto item)
    {
        return Ok(await _service.UpdateAsync(id, item));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}