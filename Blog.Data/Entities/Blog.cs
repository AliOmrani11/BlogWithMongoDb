using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Data.Entities;

public class Blog : BaseEntity
{
    public Blog()
    {
        this.Id = Guid.NewGuid();
        this.InsertedDate = DateTime.Now;
    }
    
    
    [BsonRequired]
    public string? Slug { get; set; }
    public string? KeyWords { get; set; }
    public int Time { get; set; }
    public string? Lead { get; set; }
    public string? MainPhoto { get; set; }
    public string? ThumbMail { get; set; }
    [BsonRequired]
    public bool Publish { get; set; }
    [BsonRequired]
    public bool Index { get; set; }
    public string? TableOfContent { get; set; }
    public int Type { get; set; }
    public Guid? AuthorId { get; set; }
    public List<Guid> Tags { get; set; } = new List<Guid>();
    public List<Guid> Categories { get; set; } = new List<Guid>();
    
    
    
}