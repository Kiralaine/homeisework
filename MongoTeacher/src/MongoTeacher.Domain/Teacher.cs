using MongoDB.Bson.Serialization.Attributes;

namespace MongoTeacher.Domain;

public class Teacher
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