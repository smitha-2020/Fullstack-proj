using System.Text.Json.Serialization;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOProductResponse
{
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public DTOCategoryResponse Category { get; set; } = null!;

    // //many to many relationship
    public ICollection<DTOImage> ImageLink { get; set; } = null!;
}