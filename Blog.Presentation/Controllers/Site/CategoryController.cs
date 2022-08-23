using System.Net;
using Blog.Application.CQRS.Query.Category.SiteAllCategory;
using Blog.Application.CQRS.Query.Category.SiteCategory;
using Blog.Data.Results;
using Blog.Data.Results.Site;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Site;

[ApiExplorerSettings(GroupName = "Site-v1")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(SiteRoutes.Category.AllCategory)]
    [ProducesResponseType(typeof(ApiResult<List<SiteAllCategoryDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new SiteAllCategoryDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<SiteCategoryResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Category.CategoryBySlug)]
    [ProducesResponseType(typeof(ApiResult<SiteCategoryByIdResultDto>),
        (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById([FromRoute] SiteCategoryDto entry)
    {
        var result = await _mediator.Send(entry);

        return Ok(new ApiResult<SiteCategoryByIdResultDto>
        {
            Result = result
        });
    }
}