using Microsoft.AspNetCore.Mvc;
using SpaghettiCommerce.Services;

namespace SpaghettiCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv)
    {
        var result = await _orderService.Checkout(cartId, cardNumber, cardExpiry, cvv);

        return Ok(result);
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetOrder(int id)
    {
        var order = await _orderService.GetOrder(id);

        return Ok(order);
    }
    
    [HttpGet("customer/{id}")]
    public async Task<ActionResult<string>> GetOrders(int id)
    {
        var orders = await _orderService.GetCustomerOrders(id);

        return Ok(orders);
    }
}
