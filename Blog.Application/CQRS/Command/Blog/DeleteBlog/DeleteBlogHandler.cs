using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Blog.DeleteBlog;

public class DeleteBlogHandler : IRequestHandler<DeleteBlogDto , ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public DeleteBlogHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }
    
    public async Task<ServiceResult<string>> Handle(DeleteBlogDto request, CancellationToken cancellationToken)
    {
        var blog = await _db.BlogRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        if (blog == null)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "پستی با این مشخصات وجود ندارد"
            };
        }
        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        blog.DeletedDate = DateTime.Now;
        blog.DeletedUsername = username;
        await _db.BlogRepository.UpdateAsync(blog);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}