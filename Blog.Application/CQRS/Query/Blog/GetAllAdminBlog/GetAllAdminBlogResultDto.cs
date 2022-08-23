namespace Blog.Application.CQRS.Query.Blog.GetAllAdminBlog;

public class GetAllAdminBlogResultDto
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? Title { get; set; }
    public bool Publish { get; set; }
    public bool Index { get; set; }
    public DateTime InsertedDate { get; set; }
    public string? InsertedUsername { get; set; }
}