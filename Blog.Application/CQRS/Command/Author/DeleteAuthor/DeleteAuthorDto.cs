using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Author.DeleteAuthor;

public class DeleteAuthorDto : IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
}