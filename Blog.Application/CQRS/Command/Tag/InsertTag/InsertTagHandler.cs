using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Blog.Application.CQRS.Command.Tag.InsertTag;

public class InsertTagHandler : IRequestHandler<InsertTagDto , ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public InsertTagHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }

    public async Task<ServiceResult<string>> Handle(InsertTagDto request, CancellationToken cancellationToken)
    {
        var exists =await _db.TagRepository.AnyAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نامک تکراری می باشد"
            };
        }

        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        Data.Entities.Tag tag = new Data.Entities.Tag()
        {
            Content = request.Content,
            Description = request.Description,
            Header = request.Header,
            Index = request.Index,
            Name = request.Name,
            Slug = request.Slug,
            Title = request.Title,
            InsertedUsername = username
        };
        await _db.TagRepository.CreateAsync(tag);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}