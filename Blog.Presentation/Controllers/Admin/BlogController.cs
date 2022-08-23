using System.Net;
using Blog.Application.CQRS.Command.Blog.DeleteBlog;
using Blog.Application.CQRS.Command.Blog.DeleteBlog;
using Blog.Application.CQRS.Command.Blog.DeleteBlog;
using Blog.Application.CQRS.Command.Blog.InsertBlog;
using Blog.Application.CQRS.Command.Blog.UpdateBlog;
using Blog.Application.CQRS.Query.Blog.GetAllAdminBlog;
using Blog.Application.CQRS.Query.Blog.GetAdminBlogById;
using Blog.Data.Results;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "Admin-v1")]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost(AdminRoutes.Blog.Insert)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertBlogDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpPost(AdminRoutes.Blog.Update)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateBlogDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpDelete(AdminRoutes.Blog.Delete)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] DeleteBlogDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message ?? ""));
        }

        return Ok(new ApiBaseResult());
    }

    [HttpGet(AdminRoutes.Blog.GetAll)]
    [ProducesResponseType(typeof(ApiResult<List<GetAllAdminBlogResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send<List<GetAllAdminBlogResultDto>>(new GetAllAdminBlogDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<GetAllAdminBlogResultDto>>()
        {
            Result = result
        });
    }


    [HttpGet(AdminRoutes.Blog.Get)]
    [ProducesResponseType(typeof(ApiResult<GetAdminBlogByIdResultDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetById([FromRoute] GetAdminBlogByIdDto entry)
    {
        var result = await _mediator.Send<GetAdminBlogByIdResultDto>(entry);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(new ApiResult<GetAdminBlogByIdResultDto>()
        {
            Result = result
        });
    }
}