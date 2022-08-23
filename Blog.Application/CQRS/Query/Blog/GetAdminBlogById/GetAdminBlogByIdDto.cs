using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetAdminBlogById;

public class GetAdminBlogByIdDto : IRequest<GetAdminBlogByIdResultDto>
{
    public Guid Id { get; set; }
}