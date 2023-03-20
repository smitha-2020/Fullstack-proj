using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOUpdateImage
{
    public string ImageURL { get; set; } = null!;
}

