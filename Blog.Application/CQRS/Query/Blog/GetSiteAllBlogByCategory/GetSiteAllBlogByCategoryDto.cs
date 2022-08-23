using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByCategory;

public class GetSiteAllBlogByCategoryDto : IRequest<List<GetSiteAllBlogResultDto>>
{
    public string? Slug { get; set; }
}