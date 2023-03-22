using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using backend.src.DTOs;

namespace backend.src.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;

    [JsonIgnore]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; } = null!;
    //many to many relationship
    public ICollection<Image> ImageLink { get; set; } = null!;
}
