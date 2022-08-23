using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Tag.DeleteTag;

public class DeleteTagDto : IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
}