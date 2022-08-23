using FluentValidation;

namespace Blog.Application.CQRS.Command.Blog.UpdateBlog;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
{
    public UpdateBlogValidator()
    {

        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("کد پست را وارد کنید");
        
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