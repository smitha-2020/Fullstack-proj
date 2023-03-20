namespace backend.src.DTOs.DTOResponse;

public class DTOImageUpdatedResponse
{
    public int Id { get; set; }
    public Uri ImageURL { get; set; } = null!;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}