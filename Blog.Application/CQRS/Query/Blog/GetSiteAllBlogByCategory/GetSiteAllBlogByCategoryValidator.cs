using FluentValidation;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByCategory;

public class GetSiteAllBlogByCategoryValidator : AbstractValidator<GetSiteAllBlogByCategoryDto>
{
    public GetSiteAllBlogByCategoryValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("گروهی را انتخاب نکردید");
    }
}