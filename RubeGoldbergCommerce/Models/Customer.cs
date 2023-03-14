namespace RubeGoldbergCommerce.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string DeliveryAddress { get; set; }

    public List<Order> Orders { get; set; }
}
