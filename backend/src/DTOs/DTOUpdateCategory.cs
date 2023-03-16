using backend.src.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.src.DTOs;

public class DTOUpdateCategory
{
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;

}