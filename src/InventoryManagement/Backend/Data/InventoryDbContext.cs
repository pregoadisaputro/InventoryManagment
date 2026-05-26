using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
}
