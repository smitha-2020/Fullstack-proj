namespace backend.src.Models;

public class Image : BaseModel
{
    public Uri ImageURL { get; set; } = null!;

    public ICollection<Category> Categorys {get; set;} = null!;
}