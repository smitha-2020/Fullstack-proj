using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.src.Models;

public class CartItem : BaseModel
{
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Products { get; set; } = null!;

    public int Quantity { get; set; }
}