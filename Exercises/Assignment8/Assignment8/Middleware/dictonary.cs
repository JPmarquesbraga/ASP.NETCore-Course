using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Assignment8.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class dictonary
    {
        private readonly RequestDelegate _next;

        public dictonary(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["countries"] = new Dictionary<int, string>
            {
                { 1, "Unites States"},
                { 2, "Canada"},
                { 3, "United Kingdom"},
                { 4, "India"},
                { 5, "Japan"}
            };

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class dictonaryExtensions
    {
        public static IApplicationBuilder UseDictonary(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<dictonary>();
        }
    }
}
