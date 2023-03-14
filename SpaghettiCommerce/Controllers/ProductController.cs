using Microsoft.AspNetCore.Mvc;
using SpaghettiCommerce.Products;

namespace SpaghettiCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetProduct(int id)
    {
        var product = await _productService.GetProduct(id);

        return Ok(product);
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<string>> SearchProducts(string searchTerm)
    {
        var products = await _productService.SearchProducts(searchTerm);

        return Ok(products);
    }
}
