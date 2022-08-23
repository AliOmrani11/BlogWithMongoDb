using MediatR;

namespace Blog.Application.CQRS.Query.Category.SiteCategory;

public class SiteCategoryDto : IRequest<SiteCategoryByIdResultDto>
{
    public string? Slug { get; set; }
    
}