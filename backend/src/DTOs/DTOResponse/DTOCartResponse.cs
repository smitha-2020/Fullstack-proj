using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCartResponse
{
    public int Id {get; set;}
    public Guid UserId { get; set; }
    public ICollection<DTOCartItemResponse> CartItems { get; set; } = null!;
}