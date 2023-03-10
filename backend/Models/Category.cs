using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;
}