using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Blog.Data.Entities;

public abstract class BaseEntity
{
    [BsonId(IdGenerator = typeof(GuidGenerator))]
    public Guid Id { get; set; }
    
    [BsonRequired]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime InsertedDate { get; set; }
    
    [BsonRequired]
    public string? InsertedUsername { get; set; }

    public string? Header { get; set; }
    
    public string? Title { get; set; }
    
    public string? Content { get; set; }
    
    public string? Description { get; set; }
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
    public DateTime? EditedDate { get; set; }
    
    public string? EditedUsername { get; set; }
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
    public DateTime? DeletedDate { get; set; }
    
    public string? DeletedUsername { get; set; }
}