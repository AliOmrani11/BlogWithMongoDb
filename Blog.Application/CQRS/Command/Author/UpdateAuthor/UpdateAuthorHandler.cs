using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Author.UpdateAuthor;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorDto, ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public UpdateAuthorHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }


    public async Task<ServiceResult<string>> Handle(UpdateAuthorDto request, CancellationToken cancellationToken)
    {
        var author = await _db.AuthorRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        if (author==null)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نویسنده ای با این مشخصات وجود ندارد"
            };
        }


        var exists =
            await _db.AuthorRepository.AnyAsync(s =>
                s.Slug == request.Slug && s.Id != request.Id && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نویسنده تکراری می باشد"
            };
        }

        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";

        author.Content = request.Content;
        author.Description = request.Description;
        author.Header = request.Header;
        author.Family = request.Family;
        author.Name = request.Name;
        author.Slug = request.Slug;
        author.Title = request.Title;
        author.EditedUsername = username;
        author.EditedDate=DateTime.Now;
        await _db.AuthorRepository.UpdateAsync(author);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}