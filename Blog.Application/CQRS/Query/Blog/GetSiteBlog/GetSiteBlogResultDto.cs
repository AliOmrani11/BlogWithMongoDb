using Blog.Data.Results.Site;

namespace Blog.Application.CQRS.Query.Blog.GetSiteBlog;

public class GetSiteBlogResultDto
{
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
    public DateTime Date { get; set; }
    public SiteAuhtorResultDto Author { get; set; }
    public List<SiteTagResultDto> Tags { get; set; }
    public List<SiteCategoryResultDto> Category { get; set; }
}