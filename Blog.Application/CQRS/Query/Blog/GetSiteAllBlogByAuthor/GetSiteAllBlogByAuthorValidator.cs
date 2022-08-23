using FluentValidation;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByAuthor;

public class GetSiteAllBlogByAuthorValidator : AbstractValidator<GetSiteAllBlogByAuthorDto>
{
    public GetSiteAllBlogByAuthorValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("نویسنده ای را انتخاب نکردید");
    }
}