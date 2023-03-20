using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOUpdateProduct
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<string> Images { get; set; } = null!;
}

