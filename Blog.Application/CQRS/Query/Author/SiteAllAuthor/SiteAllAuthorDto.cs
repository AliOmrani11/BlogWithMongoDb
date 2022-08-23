using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Author.SiteAllAuthor;

public class SiteAllAuthorDto : IRequest<List<SiteAuhtorResultDto>>
{
    
}