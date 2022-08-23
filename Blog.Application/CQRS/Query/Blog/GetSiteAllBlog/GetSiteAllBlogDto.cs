using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlog;

public class GetSiteAllBlogDto : IRequest<List<GetSiteAllBlogResultDto>>
{
}