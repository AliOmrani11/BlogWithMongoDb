using MediatR;

namespace Blog.Application.CQRS.Query.Author.AuthorById;

public class AuthorByIdDto : IRequest<AuthorByIdResultDto>
{
    public Guid Id { get; set; }
}