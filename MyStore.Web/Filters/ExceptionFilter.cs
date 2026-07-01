using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyStore.Domain.Exceptions;
using MyStore.Application.Messages;

namespace MyStore.Web.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException domainException)
            HandleDomainException(context, domainException);

        else
            HandleUnknownError(context);
    }

    private void HandleDomainException(ExceptionContext context, DomainException ex)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Result = new ObjectResult(new { errors = new[] { ex.Message } });
    }
    private void HandleUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new { errors = new[] { ResourceErrorMessages.UNKNOWN_ERROR } });
    }
}
