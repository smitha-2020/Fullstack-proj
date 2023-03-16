using System.Text.Json.Serialization;

namespace backend.src.Models;

public class Cart : BaseModel
{
    public Guid UserId { get; set; }

    [JsonIgnore]
    public ICollection<CartItem> CartItems { get; set; } = null!;
}