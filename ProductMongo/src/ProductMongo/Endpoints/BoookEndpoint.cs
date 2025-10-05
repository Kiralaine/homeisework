using ProductMongo.App.Interfaces;
using ProductMongo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProductMongo.Endpoints;

[Route("api/products")]
[ApiController]
public class BoookEndpoint
{
    private readonly IMongoProduct _mongoProduct;

    [HttpPost]
    public async Task<long> AddProduct(Product product)
    {
        await _mongoProduct.AddProduct(product);
        return product.Id;
    }

    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        return await _mongoProduct.GetProducts();
    }

    [HttpGet("{id}")]
    public async Task<Product> GetProduct(long id)
    {
        return await _mongoProduct.GetProduct(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteProduct(long id)
    {
        var product = await _mongoProduct.GetProduct(id);
        await _mongoProduct.DeleteProduct(product);
    }
}