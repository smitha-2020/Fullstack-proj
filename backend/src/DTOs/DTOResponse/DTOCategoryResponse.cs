namespace backend.src.DTOs.DTOResponse;

public class DTOCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;
}

public class DTOCategoryProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DTOImageResponse Image { get; set; } = null!;
    public ICollection<DTOProductResponse> Products { get; set; } = null!;
}

public class DTOCategoryImageResponse
{
    public int Id {get; set;}
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;
    public ICollection<DTOProductCategoryResponse> Products { get; set; } = null!;
}

public class DTOCategoryUpdatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
