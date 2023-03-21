using backend.src.Services.RoleService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

public class RoleController : ApiController
{
    private readonly IRoleService _service;
    private readonly ILogger<RoleController> _logger;

    public RoleController(IRoleService service, ILogger<RoleController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] ICollection<string> names)
    {
        var result = await _service.AddRolesAsync(names);
        if (result.Count() > 0)
        {
            return Ok($"Added {result.Count()} roles to the database.");
        }
        return BadRequest();
    }

    // [HttpPost("{userId:Guid}/assign")]
    // public async Task<IActionResult> AssignRoleToUser(Guid id,[FromBody] ICollection<Guid> names)
    // {
    //     return Ok(await _service.AssignRoleToUserAsync(id,names));
    // }

    [HttpGet]
    public async Task<ActionResult<IList<IdentityRole<Guid>>>> GetRoles()
    {
        return await _service.GetRolesAsync();
    }
}