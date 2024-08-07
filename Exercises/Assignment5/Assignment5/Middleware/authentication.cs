using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Assignment5.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class authentication
    {
        private readonly RequestDelegate _next;

        public authentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Method != "POST")
            {
                httpContext.Response.StatusCode = 200;
                httpContext.Response.WriteAsync("No response");
                return;
            }
               
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class authenticationExtensions
    {
        public static IApplicationBuilder Useauthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<authentication>();
        }
    }
}
