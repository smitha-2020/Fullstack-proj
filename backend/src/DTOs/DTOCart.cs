using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCart : BaseDTO<Cart>
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }



    // public int CartId { get; set; }
    // public Cart? Cart { get; set; }


    //public ICollection<CartItem> CartItems { get; set; } = null!;

    // public int ProductId { get; set; }
    // //public Product? Products { get; set; } = null!;

    // public int Quantity { get; set; }
}