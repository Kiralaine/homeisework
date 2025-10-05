using MongoDB.Bson.Serialization.Attributes;
namespace BookMongo.Domain;

public class Book
{
    [BsonId]
    [BsonElement("id")]
    public long Id { get; set; }
    public string Name { get; set; }
    
}