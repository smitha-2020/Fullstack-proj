using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCart : BaseDTO<Cart>
{
    public Guid UserId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    public int Quantity { get; set; }
}

public class DTOCartResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public DTOUserResponse Users { get; set; } = null!;
    public DTOProductResponse Products { get; set; } = null!;
    public int Quantity { get; set; }
}

public class DTOUpdateCart
{
   public int Quantity { get; set; }
   public int ProductId { get; set; }
}