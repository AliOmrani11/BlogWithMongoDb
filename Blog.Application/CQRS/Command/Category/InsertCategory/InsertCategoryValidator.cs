using FluentValidation;

namespace Blog.Application.CQRS.Command.Category.InsertCategory;

public class InsertCategoryValidator : AbstractValidator<InsertCategoryDto>
{
    public InsertCategoryValidator()
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