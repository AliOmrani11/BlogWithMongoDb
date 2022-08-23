using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByTag;

public class GetSiteAllBlogByTagDto : IRequest<List<GetSiteAllBlogResultDto>>
{
    public string? Slug { get; set; }
}