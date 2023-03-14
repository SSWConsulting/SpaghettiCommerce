using Microsoft.EntityFrameworkCore;
using RubeGoldbergCommerce.Models;
using OrderProduct = RubeGoldbergCommerce.Models.Product;
using Product = RubeGoldbergCommerce.Products.Product;

namespace RubeGoldbergCommerce.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartITems { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<OrderProduct> Products { get; set; }

    public DbSet<Product> CatalogProducts { get; set; }
}
