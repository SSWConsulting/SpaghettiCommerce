using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Data;
using SpaghettiCommerce.Models;

namespace SpaghettiCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}/orders")]
    public async Task<ActionResult<List<Order>>> GetOrders(int id)
    {
        var orders = await _context.Customers
            .Where(c => c.Id == id)
            .Select(c => c.Orders)
            .FirstOrDefaultAsync();

        return Ok(orders);
    }
}
