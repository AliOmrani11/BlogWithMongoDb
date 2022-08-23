using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Tag.DeleteTag;

public class DeleteTagHandler : IRequestHandler<DeleteTagDto , ServiceResult<string>>
{
    
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public DeleteTagHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }
    
    public async Task<ServiceResult<string>> Handle(DeleteTagDto request, CancellationToken cancellationToken)
    {
        var tag = await _db.TagRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        if (tag == null)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "تگی با این مشخصات وجود ندارد"
            };
        }
        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        tag.DeletedDate = DateTime.Now;
        tag.DeletedUsername = username;
        await _db.TagRepository.UpdateAsync(tag);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}