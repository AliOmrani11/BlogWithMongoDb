using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Blog.InsertBlog;

public class InsertBlogHandler : IRequestHandler<InsertBlogDto , ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public InsertBlogHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }

    public async Task<ServiceResult<string>> Handle(InsertBlogDto request, CancellationToken cancellationToken)
    {
        var exists =_db.BlogRepository != null && await _db.BlogRepository.AnyAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نامک تکراری می باشد"
            };
        }
        
        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        Data.Entities.Blog blog = new Data.Entities.Blog()
        {
            Categories = request.Categories,
            Content = request.Content,
            Description = request.Description,
            Header = request.Header,
            Index = request.Index,
            Lead = request.Lead,
            Publish = request.Publish,
            Slug = request.Slug,
            Tags = request.Tags,
            Time = request.Time,
            Type = request.Type,
            Title = request.Title,
            AuthorId = request.AuthorId,
            InsertedDate = DateTime.Now,
            KeyWords = request.KeyWords,
            MainPhoto = request.MainPhoto,
            ThumbMail = request.ThumbMail,
            TableOfContent = request.TableOfContent,
            InsertedUsername = username
        };
        if (_db.BlogRepository != null) 
            await _db.BlogRepository.CreateAsync(blog);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}