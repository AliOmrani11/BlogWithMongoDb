using FluentValidation;

namespace Blog.Application.CQRS.Query.Tag.SiteTag;

public class SiteTagValidator : AbstractValidator<SiteTagDto>
{
    public SiteTagValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("تگی را انتخاب نکردید");
    }
}