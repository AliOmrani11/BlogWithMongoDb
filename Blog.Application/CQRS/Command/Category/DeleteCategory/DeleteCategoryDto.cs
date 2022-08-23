using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Category.DeleteCategory;

public class DeleteCategoryDto : IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
}