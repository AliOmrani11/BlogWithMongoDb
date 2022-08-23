using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Tag.SiteAllTag;

public class SiteAllTagDto : IRequest<List<SiteTagResultDto>>
{
    
}