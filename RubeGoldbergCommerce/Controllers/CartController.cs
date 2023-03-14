using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubeGoldbergCommerce.Data;
using RubeGoldbergCommerce.Models;

namespace RubeGoldbergCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> GetCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        return Ok(cart);
    }

    [HttpPut("{cartId/productId/count}")]
    public async Task<ActionResult> Put(int cartId, int productId, int count)
    {
        var cart = await _context.Carts.FindAsync(cartId);

        if (cart is null)
        {
            cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = productId,
                        Count = count
                    }
                }
            };
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductId = productId,
                Count = count
            });
        }

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{cartId/productId}")]
    public async Task<ActionResult> Delete(int cartId, int productId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == cartId);

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        cart.Items.Remove(item);

        return Ok();
    }
}
