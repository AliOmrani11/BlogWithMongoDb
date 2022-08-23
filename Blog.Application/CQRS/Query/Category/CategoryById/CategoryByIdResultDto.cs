namespace Blog.Application.CQRS.Query.Category.CategoryById;

public class CategoryByIdResultDto
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public bool Index { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}