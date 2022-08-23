using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Category.SiteAllCategory;

public class SiteAllCategoryDto : IRequest<List<SiteCategoryResultDto>>
{
}