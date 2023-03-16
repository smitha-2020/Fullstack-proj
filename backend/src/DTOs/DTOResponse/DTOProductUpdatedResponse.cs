namespace backend.src.DTOs.DTOResponse;

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