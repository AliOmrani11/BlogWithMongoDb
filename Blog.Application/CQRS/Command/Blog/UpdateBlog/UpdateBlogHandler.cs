using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Blog.UpdateBlog;

public class UpdateBlogHandler : IRequestHandler<UpdateBlogDto, ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public UpdateBlogHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }


    public async Task<ServiceResult<string>> Handle(UpdateBlogDto request, CancellationToken cancellationToken)
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

        var exists = _db.BlogRepository != null && await _db.BlogRepository.AnyAsync(s =>
            s.Slug == request.Slug && s.Id != request.Id && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نامک تکراری می باشد"
            };
        }


        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        blog.Categories = request.Categories;
        blog.Content = request.Content;
        blog.Description = request.Description;
        blog.Header = request.Header;
        blog.Index = request.Index;
        blog.Lead = request.Lead;
        blog.Publish = request.Publish;
        blog.Slug = request.Slug;
        blog.Tags = request.Tags;
        blog.Time = request.Time;
        blog.Type = request.Type;
        blog.Title = request.Title;
        blog.AuthorId = request.AuthorId;
        blog.InsertedDate = DateTime.Now;
        blog.KeyWords = request.KeyWords;
        blog.MainPhoto = request.MainPhoto;
        blog.ThumbMail = request.ThumbMail;
        blog.TableOfContent = request.TableOfContent;
        blog.EditedUsername = username;
        blog.EditedDate = DateTime.Now;
        if (_db.BlogRepository != null)
            await _db.BlogRepository.UpdateAsync(blog);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}