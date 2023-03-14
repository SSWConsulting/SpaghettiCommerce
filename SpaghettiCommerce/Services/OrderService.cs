using SpaghettiCommerce.Data;
using SpaghettiCommerce.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SpaghettiCommerce.Services;

public interface IOrderService
{
    Task<Order> GetOrder(int id);

    Task<List<Order>> GetCustomerOrders(int customerId);

    Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv);
}

public class OrderService : IOrderService
{
    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public AppDbContext _context { get; }

    public async Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv)
    {
        var httpClient = new HttpClient();

        var requestBody = new
        {
            cardNumber = cardNumber,
            cardExpiry = cardExpiry,
            cvv = cvv
        };

        var response = await httpClient.PostAsJsonAsync("https://spaghettipayments.com/api/payment", requestBody);

        if (response.IsSuccessStatusCode)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            var orderItems = new List<OrderItem>();

            foreach (var item in cart.Items)
            {
                orderItems.Add(new OrderItem
                {
                    Product = item.Product,
                    Count = item.Count
                });
            }
            
            var order = new Order
            {
                Customer = cart.Customer,
                CustomerId = cart.Customer.Id,
                Items = orderItems,
                OrderTotal = cart.Total,
                CustomerOrderRef = Guid.NewGuid().ToString()
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            await SendEmailNotification(cart.Customer.Email, order.CustomerOrderRef);

            return order.CustomerOrderRef;
        }
        else
        {
            throw new Exception("Payment failed");
        }
    }

    public async Task<List<Order>> GetCustomerOrders(int customerId)
    {
        var orders = await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();

        return orders;
    }

    public async Task<Order> GetOrder(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    private async Task SendEmailNotification(string to, string orderRef)
    {
        // Create a new MailMessage object
        MailMessage message = new MailMessage();

        // Set the sender and recipient addresses
        message.From = new MailAddress("orders@spaghetticommerce.com");
        message.To.Add(to);

        // Set the subject and body of the message
        message.Subject = "Order received";
        message.Body = $"Good news! Your order #{orderRef} has been received and will be on its way soon.";

        // Create a new SmtpClient object and set the SMTP server and port
        SmtpClient smtpClient = new SmtpClient("smtp.spaghetticommerce.com", 587);

        // Set the credentials for the SMTP server (if required)
        smtpClient.Credentials = new NetworkCredential("orders", "5p4gh3tt1");

        // Send the message
        smtpClient.SendAsync(message, CancellationToken.None);
    }
}
