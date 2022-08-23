using MediatR;

namespace Blog.Application.CQRS.Query.Author.AllAuthor;

public class AllAuthorDto : IRequest<List<AllAuthorResultDto>>
{
}