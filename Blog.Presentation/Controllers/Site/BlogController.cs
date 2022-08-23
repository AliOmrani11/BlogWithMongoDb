using System.Net;
using Blog.Application.CQRS.Query.Blog.GetSiteAllBlog;
using Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByAuthor;
using Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByCategory;
using Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByTag;
using Blog.Application.CQRS.Query.Blog.GetSiteBlog;
using Blog.Data.Results;
using Blog.Data.Results.Site;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Site;

[ApiExplorerSettings(GroupName = "Site-v1")]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(SiteRoutes.Blog.AllBlog)]
    [ProducesResponseType(typeof(ApiResult<List<GetSiteAllBlogResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllBlog()
    {
        var result = await _mediator.Send(new GetSiteAllBlogDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<GetSiteAllBlogResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Blog.AllBlogByTag)]
    [ProducesResponseType(typeof(ApiResult<List<GetSiteAllBlogResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllBlogByTag([FromRoute] GetSiteAllBlogByTagDto entry)
    {
        var result = await _mediator.Send(entry);
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<GetSiteAllBlogResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Blog.AllBlogByCategory)]
    [ProducesResponseType(typeof(ApiResult<List<GetSiteAllBlogResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllBlogByCategory([FromRoute] GetSiteAllBlogByCategoryDto entry)
    {
        var result = await _mediator.Send(entry);
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<GetSiteAllBlogResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Blog.AllBlogByAuthor)]
    [ProducesResponseType(typeof(ApiResult<List<GetSiteAllBlogResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllBlogByAuthor([FromRoute] GetSiteAllBlogByAuthorDto entry)
    {
        var result = await _mediator.Send(entry);
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<GetSiteAllBlogResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Blog.GetBlog)]
    [ProducesResponseType(typeof(ApiResult<GetSiteBlogResultDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBlog([FromRoute] GetSiteBlogDto entry)
    {
        var result = await _mediator.Send(entry);

        return Ok(new ApiResult<GetSiteBlogResultDto>
        {
            Result = result
        });
    }
}