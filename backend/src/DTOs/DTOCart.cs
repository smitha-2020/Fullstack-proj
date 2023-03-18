using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCart : BaseDTO<Cart>
{
    public Guid UserId { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = null!;
}