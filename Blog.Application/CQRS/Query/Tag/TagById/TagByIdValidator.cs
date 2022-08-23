using FluentValidation;

namespace Blog.Application.CQRS.Query.Tag.TagById;

public class TagByIdValidator : AbstractValidator<TagByIdDto>
{
    public TagByIdValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("تگی را انتخاب نکردید");
    }
}