using FluentValidation;

namespace Blog.Application.CQRS.Command.Tag.InsertTag;

public class InsertTagValidator : AbstractValidator<InsertTagDto>
{
    public InsertTagValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .WithMessage("نام را وارد کنید");

        RuleFor(s => s.Slug)
            .NotEmpty()
            .WithMessage("نامک را ئادر کنید");

        RuleFor(s => s.Title)
            .NotEmpty()
            .WithMessage("عنوان را وارد نمایید");
        
        RuleFor(s => s.Description)
            .NotEmpty()
            .WithMessage("توضیحات را وارد نمایید");
        
        RuleFor(s => s.Header)
            .NotEmpty()
            .WithMessage("سربرگ را وارد نمایید");
        
        RuleFor(s => s.Content)
            .NotEmpty()
            .WithMessage("محتوا را وارد نمایید");
    }
}