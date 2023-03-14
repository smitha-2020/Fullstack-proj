using Microsoft.AspNetCore.Mvc;
using backend.src.Services;
using backend.src.Models;
using backend.src.DTOs;
using backend.src.Repository;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;

namespace backend.src.Controllers;

public abstract class BaseController<TModel, TCreateDto, TUpdateDto, TResponse> : ApiController
{
    private readonly IBaseService<TModel, TCreateDto, TUpdateDto, TResponse> _service;

    public BaseController(IBaseService<TModel, TCreateDto, TUpdateDto, TResponse> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TResponse>?>> GetAll([FromQuery] QueryOptions options)
    {
        return Ok(await _service.GetAllAsync(options));
    }

    [HttpPost]
    public async Task<IActionResult> Create(TCreateDto item)
    {
        var createdData = await _service.CreateAsync(item);
        return CreatedAtAction("created", createdData);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TResponse?>> Get(int id)
    {
        return Ok(await _service.GetAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, TUpdateDto item)
    {
        return Ok(await _service.UpdateAsync(id, item));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}