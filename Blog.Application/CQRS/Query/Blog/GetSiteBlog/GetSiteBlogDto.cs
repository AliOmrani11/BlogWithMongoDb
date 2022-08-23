using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteBlog;

public class GetSiteBlogDto : IRequest<GetSiteBlogResultDto>
{
    public string? Slug { get; set; }
    
}