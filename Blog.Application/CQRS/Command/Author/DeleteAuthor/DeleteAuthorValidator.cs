using FluentValidation;

namespace Blog.Application.CQRS.Command.Author.DeleteAuthor;

public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorDto>
{
    public DeleteAuthorValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("نویسنده ای را انتخاب نکردید");
    }
}