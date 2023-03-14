using Microsoft.EntityFrameworkCore;
using backend.src.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Npgsql;
using backend.src.Repository;
using backend.src.DB;
using backend.src.Repository.BaseRepo;

namespace backend.src.DB;

public class AppDBContext:
IdentityDbContext<User,IdentityRole<Guid>, Guid>
{
    static AppDBContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<SortBy>();
        // You can also do that automatically using Reflection

        // Use the legacy timestamp behaviour - check Npgsql for more details
        // Recommendation from Postgres: Don't use time zone in database
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private readonly IConfiguration _config;

    public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration config) : base(options) => _config = config;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbConn = _config.GetConnectionString("DefaultConnection");
        optionsBuilder
        .UseNpgsql(dbConn)
        .AddInterceptors(new AppDBContextInterceptor())
        .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

        modelBuilder.HasPostgresEnum<SortBy>();
        
        modelBuilder.Entity<Product>().Navigation(x => x.Category).AutoInclude();

        modelBuilder.AddIdentityConfig();
    }
    public DbSet<Category> Categorys { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
}