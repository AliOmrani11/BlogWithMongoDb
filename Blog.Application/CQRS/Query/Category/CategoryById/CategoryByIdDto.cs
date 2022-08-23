using MediatR;

namespace Blog.Application.CQRS.Query.Category.CategoryById;

public class CategoryByIdDto : IRequest<CategoryByIdResultDto>
{
    public Guid Id { get; set; }
}