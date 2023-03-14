using RubeGoldbergCommerce.Models;

namespace RubeGoldbergCommerce.Products;

public class Product
{
    public int Id { get; set; }

    public int StockCount { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }    

    public Manufacturer Manufacturer { get; set; }
    public int ManufacturerId { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }

    public Decimal Price { get; set; }
}
