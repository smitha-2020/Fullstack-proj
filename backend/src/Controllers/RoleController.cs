using backend.src.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[Authorize]
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

    [HttpPost("{userId:Guid}/assign")]
    public async Task<IActionResult> AssignRoleToUser(Guid userId, [FromBody] IEnumerable<string> names)
    {
        if (await _service.AssignRoleToUserAsync(userId, names))
        {
            return Ok($" {userId} is assigned roles.");
        }
        return BadRequest(new {Message = "Either userId is already assigned or Invalid User or Invalid Role!!"});
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(await _service.GetRolesAsync());
    }
}