using MongoDB.Bson.Serialization.Attributes;

namespace MongoStudent.Domain;

public class Student
{
    [BsonId]
    [BsonElement("id")]
    public long Id { get; set; }
    [BsonRequired]
    public string Name { get; set; }
    [BsonRequired]
    public string Email { get; set; }
    [BsonRequired]
    public string Phone { get; set; }
}