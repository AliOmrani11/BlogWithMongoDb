using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByAuthor;

public class GetSiteAllBlogByAuthorDto : IRequest<List<GetSiteAllBlogResultDto>>
{
    public string? Slug { get; set; }
}