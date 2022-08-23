using System.Net;
using Blog.Application.CQRS.Query.Tag.SiteAllTag;
using Blog.Application.CQRS.Query.Tag.SiteTag;
using Blog.Data.Results;
using Blog.Data.Results.Site;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Site;

[ApiExplorerSettings(GroupName = "Site-v1")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet(SiteRoutes.Tag.AllTag)]
    [ProducesResponseType(typeof(ApiResult<List<SiteTagResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new SiteAllTagDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<SiteTagResultDto>>
        {
            Result = result
        });
    }


    [HttpGet(SiteRoutes.Tag.TagBySlug)]
    [ProducesResponseType(typeof(ApiResult<SiteTagByIdResultDto>),
        (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById([FromRoute] SiteTagDto entry)
    {
        var result = await _mediator.Send(entry);

        return Ok(new ApiResult<SiteTagByIdResultDto>
        {
            Result = result
        });
    }
}