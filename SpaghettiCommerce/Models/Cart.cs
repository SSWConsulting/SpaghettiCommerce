namespace SpaghettiCommerce.Models;

public class Cart
{
    public int Id { get; set; }

    public List<CartItem> Items { get; set; } = new();

    public decimal Total { get; set; }

    public Customer Customer { get; set; }
}
