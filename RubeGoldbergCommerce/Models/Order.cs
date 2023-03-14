namespace RubeGoldbergCommerce.Models;

public class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }
    public int CustomerId { get; set; }

    public List<OrderItem> Items { get; set; }

    public decimal OrderTotal { get; set; }
}
