using Microsoft.AspNetCore.Mvc;
using backend.src.Services.BaseService;
using backend.src.Repository.BaseRepo;
using Microsoft.AspNetCore.Diagnostics;

namespace backend.src.Controllers;

public abstract class BaseController<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> : ApiController
{
    private readonly IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> _service;


    public BaseController(IBaseService<TModel, TCreateDto, TUpdateDto, TResponse, TUpdatedResponse> service)
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
        return Ok(await _service.CreateAsync(item));
        //return CreatedAtAction("created", item);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TResponse?>> Get(int id)
    {
        return Ok(await _service.GetAsync(id));
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult> Update(int id, TUpdateDto item)
    {
        return Ok(await _service.UpdateAsync(id, item));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }

    [Route("/error-development")]
    public IActionResult HandleErrorDevelopment(
    [FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        return Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);
    }

    [Route("/error")]
    public IActionResult HandleError() =>
        Problem();
}