namespace RubeGoldbergCommerce.Models;

public class CartItem
{
    public Cart Cart { get; set; }
    public int CartId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
}
