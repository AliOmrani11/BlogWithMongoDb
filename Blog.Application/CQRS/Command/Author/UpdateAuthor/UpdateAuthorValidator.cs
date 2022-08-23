using FluentValidation;

namespace Blog.Application.CQRS.Command.Author.UpdateAuthor;

public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
{
    public UpdateAuthorValidator()
    {
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("کد را وارد کنید");
        
        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("مشخصه را وارد کنید");

        RuleFor(s => s.Name)
            .NotEmpty()
            .WithMessage("نام را وارد کنید");
        
        RuleFor(s => s.Family)
            .NotEmpty()
            .WithMessage("نام خانوادگی را وارد کنید");
        
        RuleFor(s => s.Title)
            .NotEmpty()
            .WithMessage("عنوان را وارد کنید");
        
        RuleFor(s => s.Header)
            .NotEmpty()
            .WithMessage("سربرگ را وارد کنید");
    }
}