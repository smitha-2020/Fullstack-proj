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