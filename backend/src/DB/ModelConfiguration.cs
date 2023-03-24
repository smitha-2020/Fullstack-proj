using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.DB;

public static class ModelConfiguration
{
    public static void ConfigureProduct(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>().Navigation(x => x.Category).AutoInclude();

        modelBuilder.Entity<Product>().Navigation(x => x.ImageLink).AutoInclude();

        modelBuilder.Entity<Product>()
              .HasIndex(item => item.Title);

        modelBuilder.Entity<Product>()
                .HasIndex(item => item.Price);
    }

    public static void ConfigureCart(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>().Navigation(x => x.Products).AutoInclude();
    }

    public static void ConfigureCategory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DTOCategoryProductResponse>().Navigation(x => x.Products).AutoInclude();
        modelBuilder.Entity<DTOProductResponse>().Navigation(x => x.Category).AutoInclude();
        modelBuilder.Entity<Category>().Navigation(x => x.Products).AutoInclude();
    }
}