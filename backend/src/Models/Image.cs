namespace backend.src.Models;

public class Image : BaseModel
{
    public string ImageURL { get; set; } = null!;
    public ICollection<Product> ProductLink { get; set; } = null!;
}