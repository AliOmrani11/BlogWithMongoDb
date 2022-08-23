using System.Net;
using Blog.Application.CQRS.Query.Author.SiteAllAuthor;
using Blog.Application.CQRS.Query.Author.SiteAuthor;
using Blog.Data.Results;
using Blog.Data.Results.Site;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Site;

[ApiExplorerSettings(GroupName = "Site-v1")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet(SiteRoutes.Author.AllAuthor)]
    [ProducesResponseType(typeof(ApiResult<List<SiteAuhtorResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new SiteAllAuthorDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<SiteAuhtorResultDto>>
        {
            Result = result
        });
    }

    [HttpGet(SiteRoutes.Author.AuthorBySlug)]
    [ProducesResponseType(typeof(ApiResult<SiteAuthorByIdResultDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById([FromRoute] SiteAuthorDto entry)
    {
        var result = await _mediator.Send(entry);

        return Ok(new ApiResult<SiteAuthorByIdResultDto>
        {
            Result = result
        });
    }
}