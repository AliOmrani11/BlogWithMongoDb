namespace Blog.Application.CQRS.Query.Author.AllAuthor;

public class AllAuthorResultDto
{
    public Guid Id { get; set; }
    public string? InsertedUsername { get; set; }
    public DateTime InsertedDate { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
}