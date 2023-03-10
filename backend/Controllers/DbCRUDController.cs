using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;
using backend.DTOs;

namespace backend.Controllers;

public abstract class DbCRUDController<TModel, TDto> : ApiController
where TModel : BaseModel, new()
where TDto : BaseDTO<TModel>
{
    private readonly ICRUDService<TModel, TDto> _service;
    
    public DbCRUDController(ICRUDService<TModel, TDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ICollection<TModel>?> GetAll()
    {
        var data = _service.GetAllAsync();
        if (data is null)
        {
            return null;
        }
       return await data;
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
    public virtual async Task<ActionResult<TModel?>> Get(int id)
    {
        var data = await _service.GetAsync(id);
        if (data is null)
        {
            return NotFound("Item is not found");
        }
        return data;
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