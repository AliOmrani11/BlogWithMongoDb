using System.Net;
using Blog.Application.CQRS.Command.Tag.DeleteTag;
using Blog.Application.CQRS.Command.Tag.InsertTag;
using Blog.Application.CQRS.Command.Tag.UpdateTag;
using Blog.Application.CQRS.Query.Tag.AllTag;
using Blog.Application.CQRS.Query.Tag.TagById;
using Blog.Data.Results;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "Admin-v1")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(AdminRoutes.Tag.Insert)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertTagDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpPost(AdminRoutes.Tag.Update)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateTagDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpDelete(AdminRoutes.Tag.Delete)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] DeleteTagDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }

    [HttpGet(AdminRoutes.Tag.GetAll)]
    [ProducesResponseType(typeof(ApiResult<List<AllTagResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send<List<AllTagResultDto>>(new AllTagDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<AllTagResultDto>>()
        {
            Result = result
        });
    }


    [HttpGet(AdminRoutes.Tag.Get)]
    [ProducesResponseType(typeof(ApiResult<TagResultDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetById([FromRoute] TagByIdDto entry)
    {
        var result = await _mediator.Send<TagResultDto>(entry);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(new ApiResult<TagResultDto>()
        {
            Result = result
        });
    }
}