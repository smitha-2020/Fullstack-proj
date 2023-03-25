using System.Text.Json.Serialization;

namespace backend.src.Models;

public class Cart : BaseModel
{
    public Guid UserId { get; set; }
    public User Users { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Products { get; set; } = null!;

    public int Quantity { get; set; }
}