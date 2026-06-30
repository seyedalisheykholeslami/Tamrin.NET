using Microsoft.AspNetCore.Mvc.Filters;
using Tamrin.Services;

namespace Tamrin.ActionFilter;

public class AuthActionFilter(AuthService service,string token) : IActionFilter
{
    private readonly IActionFilter _actionFilterImplementation = null!;
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("AuthToken", out var guidString) ||
            !context.HttpContext.Request.Headers.TryGetValue("Username", out var username))
        {
            throw new UnauthorizedAccessException("احراز هویت نشده");

        }

        if (!Guid.TryParse(guidString, out var guid))
        {
            throw new UnauthorizedAccessException("GUID نامعتبر است");
        } if (!service.IsValidGuid(username.ToString(), guid))
        {
            throw new UnauthorizedAccessException("توکن نامعتبر است");
           
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _actionFilterImplementation.OnActionExecuted(context);
    }
}