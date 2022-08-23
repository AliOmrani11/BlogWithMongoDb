using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Author.DeleteAuthor;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorDto,ServiceResult<string>>
{
    
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public DeleteAuthorHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }
    
    
    public async Task<ServiceResult<string>> Handle(DeleteAuthorDto request, CancellationToken cancellationToken)
    {
        var author = await _db.AuthorRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        if (author == null)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نویسنده ای با این مشخصات وجود ندارد"
            };
        }
        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        author.DeletedDate = DateTime.Now;
        author.DeletedUsername = username;
        await _db.AuthorRepository.UpdateAsync(author);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}