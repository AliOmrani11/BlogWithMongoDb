using FluentValidation;

namespace Blog.Application.CQRS.Query.Blog.GetSiteBlog;

public class GetSiteBlogValidator : AbstractValidator<GetSiteBlogDto>
{
    public GetSiteBlogValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("بلاگی را انتخاب نکردید");
    }
}