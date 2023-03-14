namespace RubeGoldbergCommerce.Models;

public class Cart
{
    public List<CartItem> Items { get; set; }

    public decimal Total { get; set; }

    public Customer Customer { get; set; }
}
