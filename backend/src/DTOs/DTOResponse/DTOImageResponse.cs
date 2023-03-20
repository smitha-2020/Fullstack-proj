using System.ComponentModel.DataAnnotations.Schema;

namespace backend.src.DTOs.DTOResponse;

public class DTOImageResponse
{
    public int Id { get; set; }
    public string ImageURL { get; set; } = null!;
}