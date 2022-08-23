namespace Blog.Application.CQRS.Query.Category.SiteCategory;

public class SiteCategoryByIdResultDto
{
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}