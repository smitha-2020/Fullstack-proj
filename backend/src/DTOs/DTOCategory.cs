using backend.src.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.src.DTOs;

public class DTOCategory : BaseDTO<Category>
{
  [StringLength(50, MinimumLength = 5)]
  public string Name { get; set; } = String.Empty;
  
  [Url]
  public string Image { get; set; } = null!;
}

public class DTOUpdateCategory
{
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = null!;

}