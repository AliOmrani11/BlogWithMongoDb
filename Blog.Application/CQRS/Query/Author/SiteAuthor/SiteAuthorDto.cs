using MediatR;

namespace Blog.Application.CQRS.Query.Author.SiteAuthor;

public class SiteAuthorDto : IRequest<SiteAuthorByIdResultDto>
{
    public string? Slug { get; set; }
}