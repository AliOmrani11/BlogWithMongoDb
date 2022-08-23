using FluentValidation;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByTag;

public class GetSiteAllBlogByTagValidator : AbstractValidator<GetSiteAllBlogByTagDto>
{
    public GetSiteAllBlogByTagValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("تگی را انتخاب نکردید");
    }
}