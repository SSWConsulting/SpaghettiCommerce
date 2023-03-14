using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Data;

namespace SpaghettiCommerce.Products;

public interface IProductService
{
    Task<Product> GetProduct(int id);
    
    Task<List<Product>> SearchProducts( string searchTerm)
}

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetProduct(int id)
    {
        return await _context.CatalogProducts.FindAsync(id);
    }

    public async Task<List<Product>> SearchProducts(string searchTerm)
    {
        return await _context.CatalogProducts
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync();
    }
}
