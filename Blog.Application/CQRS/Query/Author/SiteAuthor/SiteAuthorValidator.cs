using FluentValidation;

namespace Blog.Application.CQRS.Query.Author.SiteAuthor;

public class SiteAuthorValidator : AbstractValidator<SiteAuthorDto>
{
    public SiteAuthorValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("نویسنده ای را انتخاب نکردید");
    }
}