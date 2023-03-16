using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCartItems : BaseDTO<CartItem>
{
    public int CartId {get; set;}
    public Cart? Cart {get; set;} = null!;

    public int ProductId { get; set; }
    public Product? Products { get; set; } = null!;

    public int Quantity { get; set; }
}