using System.Net;
using Blog.Application.CQRS.Command.Author.DeleteAuthor;
using Blog.Application.CQRS.Command.Author.InsertAuthor;
using Blog.Application.CQRS.Command.Author.UpdateAuthor;
using Blog.Application.CQRS.Query.Author.AllAuthor;
using Blog.Application.CQRS.Query.Author.AuthorById;
using Blog.Data.Results;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "Admin-v1")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(AdminRoutes.Author.Insert)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertAuthorDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpPost(AdminRoutes.Author.Update)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpDelete(AdminRoutes.Author.Delete)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] DeleteAuthorDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }

    [HttpGet(AdminRoutes.Author.GetAll)]
    [ProducesResponseType(typeof(ApiResult<List<AllAuthorResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send<List<AllAuthorResultDto>>(new AllAuthorDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<AllAuthorResultDto>>()
        {
            Result = result
        });
    }


    [HttpGet(AdminRoutes.Author.Get)]
    [ProducesResponseType(typeof(ApiResult<AuthorByIdResultDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetById([FromRoute] AuthorByIdDto entry)
    {
        var result = await _mediator.Send<AuthorByIdResultDto>(entry);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(new ApiResult<AuthorByIdResultDto>()
        {
            Result = result
        });
    }
}