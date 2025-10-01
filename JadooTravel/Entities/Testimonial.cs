using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities;

public class Testimonial
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string FullName { get; set; }
    public string CityCountry { get; set; }

}
