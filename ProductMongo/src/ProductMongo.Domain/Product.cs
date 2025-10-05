using MongoDB.Bson.Serialization.Attributes;
namespace ProductMongo.Domain;

public class Product
{
    [BsonId]
    [BsonElement("id")]
    public long Id { get; set; }
    public string Name { get; set; }
    
}