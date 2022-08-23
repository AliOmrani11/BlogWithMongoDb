namespace Blog.Application.CQRS.Query.Tag.AllTag;

public class AllTagResultDto
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public bool Index { get; set; }
}