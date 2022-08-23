using Blog.Data.Results;
using FluentValidation;

namespace Blog.Presentation.Setting
{
    internal class ExceptionHandlerMiddleware : IMiddleware
    {


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new ApiErrorResult
            {
                Error = true,
                Messages = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(response.ToString());
        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
        private static List<string> GetErrors(Exception exception)
        {
            List<string> errors = new List<string>();
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors.Select(s => s.ErrorMessage).Distinct().ToList();
            }
            else
            {
                errors.Add(exception.Message);
            }
            return errors;
        }
    }
}
