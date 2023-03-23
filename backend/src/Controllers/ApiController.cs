using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[EnableCors("CorsPolicy")]
// [Authorize]
[ApiController]
[Route("[controller]s")]
public abstract class ApiController : ControllerBase
{

}