using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Data.Entities;

public class Author : BaseEntity
{
    public Author()
    {
        this.Id = Guid.NewGuid();
        this.InsertedDate = DateTime.Now;
    }
    [BsonElement(elementName: "slug")]
    public string? Slug { get; set; }

    [BsonRequired]
    [BsonElement(elementName: "name")]
    public string? Name { get; set; }

    [BsonRequired]
    [BsonElement(elementName: "family")]
    public string? Family { get; set; }

}