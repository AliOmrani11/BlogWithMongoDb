using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Data.Entities;

public class Tag : BaseEntity
{
    public Tag()
    {
        this.Id = Guid.NewGuid();
        this.InsertedDate = DateTime.Now;
    }
    
    [BsonRequired]
    public string? Slug { get; set; }
    [BsonRequired]
    public string? Name { get; set; }
    [BsonRequired]
    public bool Index { get; set; }
}