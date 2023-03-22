using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOImage : BaseDTO<Image>
{
    [Url]
    public string ImageURL { get; set; } = null!;
}