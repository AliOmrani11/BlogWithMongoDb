using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetAllAdminBlog;

public class GetAllAdminBlogDto : IRequest<List<GetAllAdminBlogResultDto>>
{
}