using System.ComponentModel.DataAnnotations;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOProduct : BaseDTO<Product>
{
    [StringLength(50, MinimumLength = 9)]
    public string Title { get; set; } = null!;

    [Range(1, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public double Price { get; set; }

    [MinLength(10, ErrorMessage = "minimum {1} characters should be provided")]
    public string Description { get; set; } = null!;

    public ICollection<string> Images { get; set; } = null!;

    public int CategoryId { get; set; }

    public int Category { get; set; }

}

