using Microsoft.AspNetCore.Mvc;
using backend.src.Services;
using backend.src.Models;
using backend.src.DTOs;

namespace backend.src.Controllers;

public abstract class DbCRUDController<TModel, TDto, TResponseDto> : ApiController
where TModel : BaseModel, new()
where TDto : BaseDTO<TModel>
{
    private readonly ICRUDService<TModel, TDto, TResponseDto> _service;
    
    public DbCRUDController(ICRUDService<TModel, TDto, TResponseDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ICollection<TResponseDto>?> GetAll()
    {
        var data = _service.GetAllAsync();
        if (data is null)
        {
            return null;
        }
       return (ICollection<TResponseDto>?)await data;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TDto item)
    {
        var createdItem = await _service.CreateAsync(item);
        if (createdItem is null)
        {
            return BadRequest("Item could not be created");
        }
        return Ok(createdItem);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TResponseDto?>> Get(int id)
    {
        var data = await _service.GetAsync(id);
        if (data is null)
        {
            return NotFound("Item is not found");
        }
        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, TDto item)
    {
        var c = await _service.UpdateAsync(id, item);
        if (c is null)
        {
            return BadRequest("Item could not be updated");
        }
        return Ok(c);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (await _service.DeleteAsync(id))
        {
            return Ok("Item Deleted successfully");
        }
        return NotFound("Item could not be deleted");
    }
}