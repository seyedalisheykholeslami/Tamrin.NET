using Tamrin.Services;

namespace Tamrin.Middlewares;

public class AuthorizationMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(HttpContext context, AuthService authService)
    {
        if (context.Request.Path.StartsWithSegments("/swagger")||
            context.Request.Path.StartsWithSegments("/Auth/Login") ||
            context.Request.Path.StartsWithSegments("/Auth/Register"))
        {
            await next(context);
            return;
        }

        if (!context.Request.Cookies.TryGetValue("AuthToken", out var guidString) ||
            !context.Request.Cookies.TryGetValue("Username", out var username))
        {
            throw new UnauthorizedAccessException("احراز هویت نشده");

        }

        if (!Guid.TryParse(guidString, out var guid))
        {
            throw new UnauthorizedAccessException("GUID نامعتبر است");
        } if (!authService.IsValidGuid(username.ToString(), guid))
        {
            throw new UnauthorizedAccessException("توکن نامعتبر است");
           
        }

        await next(context);
    }
}