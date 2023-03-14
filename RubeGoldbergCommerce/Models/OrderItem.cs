namespace RubeGoldbergCommerce.Models;

public class OrderItem
{
    public int Id { get; set; }
    
    public Product Product { get; set; }
    public int ProdutId { get; set; }

    public Order Order { get; set; }
    public int OrderId { get; set; }

    public int Count { get; set; }
}
