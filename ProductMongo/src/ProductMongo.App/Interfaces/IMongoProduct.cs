using ProductMongo.Domain;

namespace ProductMongo.App.Interfaces;

public interface IMongoProduct
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct( long id);
    Task<long> AddProduct(Product product);
    Task DeleteProduct(Product product);
    
    
}