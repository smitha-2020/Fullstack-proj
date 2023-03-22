namespace backend.src.Models;

public abstract class BaseModel
{
    public int Id { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
    public DateTime updatedAt { get; set; } = DateTime.Now;
}