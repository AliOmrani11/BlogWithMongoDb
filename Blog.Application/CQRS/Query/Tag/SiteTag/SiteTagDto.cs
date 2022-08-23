using MediatR;

namespace Blog.Application.CQRS.Query.Tag.SiteTag;

public class SiteTagDto : IRequest<SiteTagByIdResultDto>
{
    public string? Slug { get; set; }
}