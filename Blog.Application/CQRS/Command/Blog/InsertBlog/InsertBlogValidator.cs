using FluentValidation;

namespace Blog.Application.CQRS.Command.Blog.InsertBlog;

public class InsertBlogValidator : AbstractValidator<InsertBlogDto>
{
    public InsertBlogValidator()
    {
        RuleFor(s => s.Type)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("نوع را مشخص کنید");

        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("نامک را ئادر کنید");

        RuleFor(s => s.Title)
            .NotEmpty()
            .WithMessage("عنوان را وارد نمایید");
    }
}