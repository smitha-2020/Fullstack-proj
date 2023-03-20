using backend.src.Models;

namespace backend.src.DTOs;

public class DTOImage : BaseDTO<Image>
{
    public Uri ImageURL { get; set; } = null!;
}