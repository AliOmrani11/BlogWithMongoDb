namespace Blog.Data.Results.Site;

public class GetSiteAllBlogResultDto
{
    public string? Slug { get; set; }
    public string? MainPhoto { get; set; }
    public string? Lead { get; set; }
    public DateTime Date { get; set; }
    public int Time { get; set; }
    public string? ThumbMail { get; set; }
    public bool Index { get; set; }
    public SiteAuhtorResultDto Author { get; set; }
    public List<SiteTagResultDto> Tags { get; set; }
    public List<SiteCategoryResultDto> Category { get; set; }
}