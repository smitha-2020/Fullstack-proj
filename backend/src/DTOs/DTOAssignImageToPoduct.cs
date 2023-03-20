using backend.src.Models;

namespace backend.src.DTOs;

public class DTOAssignImageToPoduct
{
    public ICollection<int> images { get; set; } = null!;
}