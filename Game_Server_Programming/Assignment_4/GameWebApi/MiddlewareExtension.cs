using Microsoft.AspNetCore.Builder;

namespace GameWebApi
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNotFoundExpeptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotFoundExceptionHandlerMiddleware>();
        }
    }
}