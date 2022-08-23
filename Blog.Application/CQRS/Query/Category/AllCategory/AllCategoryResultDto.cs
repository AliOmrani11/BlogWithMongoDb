namespace Blog.Application.CQRS.Query.Category.AllCategory;

public class AllCategoryResultDto
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public bool Index { get; set; }
    public string? InsertedUsername { get; set; }
    public DateTime InsertedDate { get; set; }
}