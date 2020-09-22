using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameWebApi
{
    public class NotFoundExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Player not found");
                return;
            }
        }
    }
}