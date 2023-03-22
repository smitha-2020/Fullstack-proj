using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers;

[Authorize]
[ApiController]
[Route("[controller]s")]
public abstract class ApiController : ControllerBase
{

}