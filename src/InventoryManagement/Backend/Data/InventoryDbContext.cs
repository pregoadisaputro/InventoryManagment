using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" }
            );

        modelBuilder
            .Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Sku = "ELEC-MOUSE-001",
                    CategoryId = 1,
                    Quantity = 50,
                    StockThreshold = 10,
                    Price = 29.99m,
                    LastUpdatedBy = "System_Seed",
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                },
                new Product
                {
                    Id = 2,
                    Name = "T-Shirt",
                    Sku = "CLTH-TSHIRT-001",
                    CategoryId = 2,
                    Quantity = 100,
                    StockThreshold = 15,
                    Price = 19.99m,
                    LastUpdatedBy = "System_Seed",
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                }
            );
    }
}
