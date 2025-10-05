using MongoDB.Bson.Serialization.Attributes;
namespace FileMongo.Domain;

public class File
{
    [BsonId]
    [BsonElement("id")]
    public long Id { get; set; }
    public string Name { get; set; }
    
}