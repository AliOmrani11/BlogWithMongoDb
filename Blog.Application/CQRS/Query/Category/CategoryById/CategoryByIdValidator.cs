using FluentValidation;

namespace Blog.Application.CQRS.Query.Category.CategoryById;

public class CategoryByIdValidator : AbstractValidator<CategoryByIdDto>
{
    public CategoryByIdValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("گروهی را انتخاب نکردید");
    }
}