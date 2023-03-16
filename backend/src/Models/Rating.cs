

namespace backend.src.Models;

public class Rating : BaseModel
{
    public double Rate { get; set; }
    public int ReviewCount { get; set; }
}