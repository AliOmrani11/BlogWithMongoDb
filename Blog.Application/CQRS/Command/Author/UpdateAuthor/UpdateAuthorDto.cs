using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Author.UpdateAuthor;

public class UpdateAuthorDto : IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}