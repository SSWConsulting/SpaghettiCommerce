﻿namespace RubeGoldbergCommerce.Models;

public class CartItem
{
    public int Id { get; set; }
    
    public Cart Cart { get; set; }
    public int CartId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }

    public int Count { get; set; }
}
