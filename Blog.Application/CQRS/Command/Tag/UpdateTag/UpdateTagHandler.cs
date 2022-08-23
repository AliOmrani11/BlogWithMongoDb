using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Tag.UpdateTag;

public class UpdateTagHandler : IRequestHandler<UpdateTagDto, ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public UpdateTagHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }

    public async Task<ServiceResult<string>> Handle(UpdateTagDto request, CancellationToken cancellationToken)
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


        var exists =
            await _db.TagRepository.AnyAsync(s => s.Slug == request.Slug && s.Id != tag.Id && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نامک تکراری می باشد"
            };
        }

        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";

        tag.Content = request.Content;
        tag.Description = request.Description;
        tag.Header = request.Header;
        tag.Index = request.Index;
        tag.Name = request.Name;
        tag.Slug = request.Slug;
        tag.Title = request.Title;
        tag.EditedUsername = username;
        tag.EditedDate = DateTime.Now;
        await _db.TagRepository.UpdateAsync(tag);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}