using MongoDB.Bson.Serialization.Attributes;
namespace SportMongo.Domain;

public class Sport
{
    [BsonId]
    [BsonElement("id")]
    public long Id { get; set; }
    public string Name { get; set; }
    
}