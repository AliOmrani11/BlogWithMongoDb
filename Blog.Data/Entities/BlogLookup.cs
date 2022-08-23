namespace Blog.Data.Entities;

public class BlogLookup : BaseEntity
{
    public string? Slug { get; set; }
    public string? KeyWords { get; set; }
    public int Time { get; set; }
    public string? Lead { get; set; }
    public string? MainPhoto { get; set; }
    public string? ThumbMail { get; set; }
    public bool Publish { get; set; }
    public bool Index { get; set; }
    public string? TableOfContent { get; set; }
    public int Type { get; set; }
    public Guid? AuthorId { get; set; }
    public List<Guid> Tags { get; set; } = new List<Guid>();
    public List<Guid> Categories { get; set; } = new List<Guid>();


    public List<Author>? Authors { get; set; }
    public List<Tag>? Tag { get; set; }
    public List<Category>? Category { get; set; }
}