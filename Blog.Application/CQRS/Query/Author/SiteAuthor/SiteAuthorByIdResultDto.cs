namespace Blog.Application.CQRS.Query.Author.SiteAuthor;

public class SiteAuthorByIdResultDto
{
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}