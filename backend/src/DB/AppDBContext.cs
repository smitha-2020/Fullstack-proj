using Microsoft.EntityFrameworkCore;
using backend.src.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Npgsql;
using backend.src.Repository.BaseRepo;
using backend.src.DTOs.DTOResponse;

namespace backend.src.DB;

public class AppDBContext :
IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Category> Categorys { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    // public DbSet<Cart> Carts { get; set; } = null!;
    // public DbSet<CartItem> CartItems { get; set; } = null!;

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

        //modelBuilder.Entity<Product>().HasIndex(x => x.Category.Id).IsUnique();
        modelBuilder.Entity<Product>().Navigation(x => x.Category).AutoInclude();

        modelBuilder.Entity<Category>().Navigation(x => x.Products).AutoInclude();

        modelBuilder.Entity<Cart>().Navigation(x => x.Products).AutoInclude();

        modelBuilder.Entity<DTOCategoryProductResponse>().Navigation(x => x.Products).AutoInclude();

        modelBuilder.Entity<Product>()
                .HasIndex(item => item.Title);
        modelBuilder.Entity<Product>()
                .HasIndex(item => item.Price);

        //modelBuilder.Entity<Cart>().Navigation(x => x.CartItems).AutoInclude();

        //modelBuilder.Entity<CartItem>().Navigation(x => x.Products).AutoInclude();

        // modelBuilder.Entity<User>()
        //     .HasOne(e => e.Cart)
        //     .WithOne(e => e.User)
        //     .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<Product>()
        //     .HasOne(s => s.Category)
        //     .WithMany()
        //     .HasForeignKey(s => s.CategoryId)
        //     .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.AddIdentityConfig();
    }

}