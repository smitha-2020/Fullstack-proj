namespace backend.src.Repository.BaseRepo;

public interface IBaseRepo<TModel>
{
    // CURD Operations
    Task<TModel?> CreateOneAsync(TModel create);
    Task<TModel?> GetByIdAsync(int id);
    Task<TModel?> UpdateOneAsync(int id, TModel update);
    Task<bool> DeleteOneAsync(int id);
    Task<IEnumerable<TModel>?> GetAllAsync(QueryOptions options);
}

public class QueryOptions
{
    public string SortByProperty { get; set; } = string.Empty;
    public string Search { get; set; } = string.Empty;
    public SortBy Sort { get; set; }
    public int CardsPerPage { get; set; } = 30;
    public int Page { get; set; } = 0;
}

public enum SortBy
{
    ASC,
    DESC
}