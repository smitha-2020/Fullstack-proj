using Microsoft.AspNetCore.Mvc;

namespace backend.src.DTOs;

public class DTOToken
{
    [FromHeader]
    public string Authorization { get; set; } = null!;
}