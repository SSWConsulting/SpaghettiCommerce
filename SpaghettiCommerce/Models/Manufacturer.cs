namespace SpaghettiCommerce.Models;

public class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
