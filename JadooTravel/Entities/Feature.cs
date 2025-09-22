using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities;

public class Feature
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } //Mongo db de object id olarak tutuluyor
    public string Title { get; set; }
    public string MainTitle { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }
}
