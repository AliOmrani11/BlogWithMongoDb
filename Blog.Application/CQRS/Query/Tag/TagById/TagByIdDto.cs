using MediatR;

namespace Blog.Application.CQRS.Query.Tag.TagById;

public class TagByIdDto : IRequest<TagResultDto>
{
    public Guid Id { get; set; }
}