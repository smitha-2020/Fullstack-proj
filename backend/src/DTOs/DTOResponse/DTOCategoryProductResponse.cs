namespace backend.src.DTOs.DTOResponse;

public class DTOCategoryProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DTOImageResponse Image { get; set; } = null!;
    public ICollection<DTOProductCategoryResponse> Products { get; set; } = null!;
}