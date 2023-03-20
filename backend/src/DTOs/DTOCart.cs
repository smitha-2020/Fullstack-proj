using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCart : BaseDTO<Cart>
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}