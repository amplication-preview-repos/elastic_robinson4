using ElectronicShopService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShopService.Infrastructure;

public class ElectronicShopServiceDbContext : DbContext
{
    public ElectronicShopServiceDbContext(DbContextOptions<ElectronicShopServiceDbContext> options)
        : base(options) { }

    public DbSet<InventoryDbModel> Inventories { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<ProductDbModel> Products { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<ClientDbModel> Clients { get; set; }

    public DbSet<OrderItemDbModel> OrderItems { get; set; }

    public DbSet<ProductCategoryDbModel> ProductCategories { get; set; }

    public DbSet<StockDbModel> Stocks { get; set; }
}
