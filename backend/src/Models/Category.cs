using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.src.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = String.Empty;

    public int? ImageId { get; set; }
    public Image? Image { get; set; }

    public ICollection<Product> Products { get; set; } = null!;
}