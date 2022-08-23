using FluentValidation;

namespace Blog.Application.CQRS.Command.Tag.DeleteTag;

public class DeleteTagValidator : AbstractValidator<DeleteTagDto>
{
    public DeleteTagValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("کد تگ را وارد نمایید");
    }
}