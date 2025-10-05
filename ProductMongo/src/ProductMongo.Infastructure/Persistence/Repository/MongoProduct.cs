using ProductMongo.App.Interfaces;
using ProductMongo.Domain;
using MongoDB.Driver;

namespace ProductMongo.Infastructure.Persistence.Repository;

public class MongoProduct : IMongoProduct
{
    private readonly IMongoCollection<Product> _collection;

    public MongoProduct(IMongoCollection<Product> collection)
    {
        _collection = collection;
    }

    public async Task<List<Product>> GetProducts()
    {
         var cursor=  await  _collection.Find(product => true).ToListAsync();
         return cursor;
         
    }

    public Task<Product> GetProduct(long id)
    {
        var cursor = _collection.Find(product => product.Id == id);
        return cursor.FirstOrDefaultAsync();
    }

    public async Task<long> AddProduct(Product product)
    {
        if (product.Id == 0)
            product.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _collection.InsertOne(product); 
        return product.Id;
    }

    public async Task DeleteProduct(Product product)
    {
        _collection.DeleteOne(product => product.Id == product.Id);
    }
}