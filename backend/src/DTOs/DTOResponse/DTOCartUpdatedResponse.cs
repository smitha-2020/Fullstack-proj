using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCartUpdatedResponse
{
    public int Id {get; set;}
    public Guid UserId { get; set; }
}