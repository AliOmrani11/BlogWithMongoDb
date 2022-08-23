using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Category.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryDto , ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public DeleteCategoryHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }
    
    
    public async Task<ServiceResult<string>> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
    {
        var category = await _db.CategoryRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        if (category == null)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "گروهی با این مشخصات وجود ندارد"
            };
        }
        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";
        category.DeletedDate = DateTime.Now;
        category.DeletedUsername = username;
        await _db.CategoryRepository.UpdateAsync(category);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}