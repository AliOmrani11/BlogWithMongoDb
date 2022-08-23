using System.IdentityModel.Tokens.Jwt;
using Blog.Application.UnitOfWork;
using Blog.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.CQRS.Command.Category.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryDto , ServiceResult<string>>
{
    private readonly IUnitOfWork _db;
    private readonly IHttpContextAccessor _accessor;

    public UpdateCategoryHandler(IUnitOfWork db, IHttpContextAccessor accessor)
    {
        _db = db;
        _accessor = accessor;
    }
    
    
    public async Task<ServiceResult<string>> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
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


        var exists =
            await _db.CategoryRepository.AnyAsync(s => s.Slug == request.Slug && s.Id != category.Id && s.DeletedDate == null);
        if (exists)
        {
            return new ServiceResult<string>()
            {
                Success = false,
                Message = "نامک تکراری می باشد"
            };
        }

        string username = _accessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value ?? "";

        category.Content = request.Content;
        category.Description = request.Description;
        category.Header = request.Header;
        category.Index = request.Index;
        category.Name = request.Name;
        category.Slug = request.Slug;
        category.Title = request.Title;
        category.EditedUsername = username;
        category.EditedDate = DateTime.Now;
        await _db.CategoryRepository.UpdateAsync(category);
        return new ServiceResult<string>()
        {
            Success = true
        };
    }
}