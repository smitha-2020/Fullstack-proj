using backend.src.Models;

namespace backend.src.DTOs;

public class DTOUpdateCart
{
    public Guid UserId { get; set; }
    //public ICollection<CartItem> CartItems { get; set; } = null!;
}