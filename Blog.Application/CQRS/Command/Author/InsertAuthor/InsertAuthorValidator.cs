using FluentValidation;

namespace Blog.Application.CQRS.Command.Author.InsertAuthor;

public class InsertAuthorValidator :AbstractValidator<InsertAuthorDto>
{
    public InsertAuthorValidator()
    {
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