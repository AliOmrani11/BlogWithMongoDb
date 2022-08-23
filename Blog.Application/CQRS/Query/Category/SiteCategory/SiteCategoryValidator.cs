using FluentValidation;

namespace Blog.Application.CQRS.Query.Category.SiteCategory;

public class SiteCategoryValidator : AbstractValidator<SiteCategoryDto>
{
    public SiteCategoryValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("گروهی را انتخاب نکردید");
    }
}