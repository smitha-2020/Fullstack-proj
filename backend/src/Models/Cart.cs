using System.Text.Json.Serialization;

namespace backend.src.Models;

public class Cart : BaseModel
{
    public Guid UserId { get; set; }
    public User User {get; set;} = null!;

    [JsonIgnore]
    public ICollection<CartItem> CartItems { get; set; } = null!;
}