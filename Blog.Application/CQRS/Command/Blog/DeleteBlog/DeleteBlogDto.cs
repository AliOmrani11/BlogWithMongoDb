using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Blog.DeleteBlog;

public class DeleteBlogDto : IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
}