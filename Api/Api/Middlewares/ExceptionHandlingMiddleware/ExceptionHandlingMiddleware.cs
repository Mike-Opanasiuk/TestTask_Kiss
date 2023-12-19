using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Api.Middlewares.ExceptionHandlingMiddleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, message);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(new ExceptionDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}