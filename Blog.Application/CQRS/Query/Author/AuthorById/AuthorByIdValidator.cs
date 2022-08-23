using FluentValidation;

namespace Blog.Application.CQRS.Query.Author.AuthorById;

public class AuthorByIdValidator : AbstractValidator<AuthorByIdDto>
{
    public AuthorByIdValidator()
    {
         RuleFor(s => s.Id)
                    .NotNull()
                    .WithMessage("شخصی را انتخاب نکردید");
    }
}