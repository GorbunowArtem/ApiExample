using System.Data.SqlTypes;

namespace DemoApi.Web;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (SqlNullValueException)
        {
            // How to handle this exception?
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

public static class RequestCultureMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}