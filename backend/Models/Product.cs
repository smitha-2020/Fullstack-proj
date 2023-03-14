using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using backend.DTOs;

namespace backend.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;

    [Column(TypeName = "jsonb")]
    public ICollection<string> Images { get; set; } = null!;

    [JsonIgnore]
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    //  public static Product ConvertToDTO(Product product)
    // {
    //     return new Product
    //     {
    //         Id = product.Id,
    //         Title = product.Title,
    //         Price = product.Price,
    //         Description = product.Description,
    //         Images = product.Images,
    //         Category = new Category
    //         {
    //             Id = product.Category.Id,
    //             Name = product.Category.Name,
    //             Image = product.Category.Image
    //         }
    //     };

    // }
}
