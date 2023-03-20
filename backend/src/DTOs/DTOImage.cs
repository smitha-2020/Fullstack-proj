using backend.src.Models;

namespace backend.src.DTOs;

public class DTOImage : BaseDTO<Image>
{
    public string ImageURL { get; set; } = null!;
}