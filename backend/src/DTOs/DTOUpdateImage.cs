using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOUpdateImage
{
    public Uri ImageURL { get; set; } = null!;
}

