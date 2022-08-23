using FluentValidation;

namespace Blog.Application.CQRS.Command.Blog.DeleteBlog;

public class DeleteBlogValidator : AbstractValidator<DeleteBlogDto>
{
    public DeleteBlogValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("کدی با این مشخصات وجود ندارد");
    }
}