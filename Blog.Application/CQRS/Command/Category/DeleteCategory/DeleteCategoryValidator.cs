using FluentValidation;

namespace Blog.Application.CQRS.Command.Category.DeleteCategory;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryDto>
{
    public DeleteCategoryValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("گروهی را انتخاب نکردید");
    }
}