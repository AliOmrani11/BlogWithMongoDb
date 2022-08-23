using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Author.InsertAuthor;

public class InsertAuthorHandler : IRequestHandler<InsertAuthorDto, ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public InsertAuthorHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }


    public async Task<ServiceResult<string>> Handle(InsertAuthorDto request, CancellationToken cancellationToken)
    {
        var exists = await _db.AuthorRepository.AnyAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نویسنده تکراری می باشد"
            };
        }

        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        Data.Entities.Author author = new Data.Entities.Author()
        {
            Content = request.Content,
            Description = request.Description,
            Header = request.Header,
            Family = request.Family,
            Name = request.Name,
            Slug = request.Slug,
            Title = request.Title,
            InsertedUsername = username,
        };
        await _db.AuthorRepository.CreateAsync(author);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}