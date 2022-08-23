namespace Blog.Application.CQRS.Query.Blog.GetAdminBlogById;

public class GetAdminBlogByIdResultDto
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? KeyWords { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public int Time { get; set; }
    public string? Lead { get; set; }
    public string? MainPhoto { get; set; }
    public string? ThumbMail { get; set; }
    public bool Publish { get; set; }
    public bool Index { get; set; }
    public string? TableOfContent { get; set; }
    public int Type { get; set; }
    public Guid? AuthorId { get; set; }
    public List<Guid> Tags { get; set; }
    public List<Guid> Categories { get; set; }
}