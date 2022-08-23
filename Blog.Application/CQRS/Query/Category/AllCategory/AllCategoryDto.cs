using MediatR;

namespace Blog.Application.CQRS.Query.Category.AllCategory;

public class AllCategoryDto : IRequest<List<AllCategoryResultDto>>
{
    
}