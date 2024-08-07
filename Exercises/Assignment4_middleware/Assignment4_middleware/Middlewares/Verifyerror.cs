using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Assignment4_middleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Verifyerror
    {
        private readonly RequestDelegate _next;

        public Verifyerror(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var isEmpty = false;
            if(!httpContext.Request.Query.ContainsKey("firstNumber") ||
                !httpContext.Request.Query.ContainsKey("secondNumber") ||
                !httpContext.Request.Query.ContainsKey("operation"))
            {
                isEmpty = true;
            }

            if (isEmpty)
            {
                httpContext.Response.StatusCode = 400;
                if (!httpContext.Request.Query.ContainsKey("firstNumber"))
                {
                    await httpContext.Response.WriteAsync("invalid input for firstNumber\n");
                }

                if (!httpContext.Request.Query.ContainsKey("secondNumber"))
                {
                    await httpContext.Response.WriteAsync("invalid input for secondNumber\n");
                }

                if (!httpContext.Request.Query.ContainsKey("operation"))
                {
                    await httpContext.Response.WriteAsync("invalid input for operation");
                }
                return;
            }


            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseVerifyerror(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Verifyerror>();
        }
    }
}
