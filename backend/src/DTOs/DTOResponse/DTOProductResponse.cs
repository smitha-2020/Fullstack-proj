using System.Text.Json.Serialization;
using backend.src.DTOs.DTOResponse;

namespace backend.src.DTOs;

public class DTOProductResponse
{
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public int CategoryId {get; set;}
    public DTOCategoryResponse Category { get; set; } = null!;

    // //many to many relationship
    public ICollection<DTOImageResponse> ImageLink { get; set; } = null!;
}

public class DTOProductUpdatedResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<string> Images { get; set; } = null!;
    public DTOCategoryResponse Category { get; set; } = null!;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}

public class DTOProductCategoryResponse
{
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<DTOImage> ImageLink { get; set; } = null!;
}