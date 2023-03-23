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
    //public DTOCategoryResponse Category { get; set; } = null!;

    // //many to many relationship
    public ICollection<DTOImageResponse> ImageLink { get; set; } = null!;
}