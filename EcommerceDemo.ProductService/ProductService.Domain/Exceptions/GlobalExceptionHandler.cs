using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductService.Domain.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An error occurred at {Path}! Message: {Message}",
            httpContext.Request.Path, exception.Message);

        var (status, title) = exception switch
        {
            //ProductNotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
            //ProductOperationException => (StatusCodes.Status500InternalServerError, "Operation Failed"),
            InvalidParamsException => (StatusCodes.Status400BadRequest, "Bad Request"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };

        httpContext.Response.StatusCode = status;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path, // Cho biết lỗi xảy ra ở đâu
            Extensions = { ["traceId"] = httpContext.TraceIdentifier }
        }, cancellationToken);

        return true;
    }
}
