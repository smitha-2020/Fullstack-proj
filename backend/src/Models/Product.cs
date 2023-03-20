using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using backend.src.DTOs;

namespace backend.src.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;

    // [Column(TypeName = "jsonb")]
    // public ICollection<string> Images { get; set; } = null!;

    //public ICollection<Image> Image { get; set; } = null!;

    //public int AvailableQuantity { get; set; }

    [JsonIgnore]
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    //many to many relationship
    public ICollection<Image> ImageLink { get; set; } = null!;
}
