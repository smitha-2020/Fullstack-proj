using backend.src.Models;

namespace backend.src.DTOs.DTOResponse;

public class DTOCategoryUpdatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DTOImageResponse Image { get; set; } = null!;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}