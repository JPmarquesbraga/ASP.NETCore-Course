using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Assignment5.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class VerifyEmail
    {
        private readonly RequestDelegate _next;

        public VerifyEmail(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {                   
            var reader = new StreamReader(httpContext.Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> querydict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            var verHeader = string.Empty;
            bool email = false;
            bool pass = false;

            if (!querydict.ContainsKey("email") || querydict["email"][0] is null ||
                querydict["email"][0] != "admin@example.com")
            {
                verHeader += "Invalid input for email\n";
                httpContext.Response.StatusCode = 400;
                email = true;
            }
            if (!querydict.ContainsKey("password") || querydict["password"][0] is null ||
                querydict["password"][0] != "admin1234")
            {
                verHeader += "Invalid input for password";
                httpContext.Response.StatusCode = 400;
                pass = true;
            }

            if(email == true && pass == false || email == false && pass == true)
            {
                httpContext.Response.WriteAsync("Invalid login");
                return;
            }

            if(httpContext.Response.StatusCode == 400) 
            {
                await httpContext.Response.WriteAsync(verHeader);
                return;
            } 
            else
            {
                httpContext.Response.WriteAsync("successful login");
            }
            await _next(httpContext);            
        }
    }
    
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VerifyEmailExtensions
    {
        public static IApplicationBuilder UseVerifyEmail(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VerifyEmail>();
        }
    }
}
