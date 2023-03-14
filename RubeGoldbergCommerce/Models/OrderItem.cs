namespace RubeGoldbergCommerce.Models;

public class OrderItem
{
    public Product Product { get; set; }
    public int ProdutId { get; set; }

    public Order Order { get; set; }
    public int OrderId { get; set; }
}
