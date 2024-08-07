using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Assignment4_middleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Operation
    {
        private readonly RequestDelegate _next;

        public Operation(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var firstNum = httpContext.Request.Query["firstNumber"];
            var secondNum = httpContext.Request.Query["secondNumber"]; 
            var operation = httpContext.Request.Query["operation"];
            var result = 0;

            if (int.TryParse(firstNum, out int number))
            {
                Console.WriteLine($"O número convertido é: {number}");
            } else
            {
                Console.WriteLine($"A string '{firstNum}' não pôde ser convertida para um número inteiro.");
                await httpContext.Response.WriteAsync($"Invalid input for 'firstNum'\n");
            }


            if (int.TryParse(secondNum, out int number2))
            {
                Console.WriteLine($"O número convertido é: {number2}");
            } else
            {
                Console.WriteLine($"A string '{secondNum}' não pôde ser convertida para um número inteiro.");
                await httpContext.Response.WriteAsync($"Invalid input for 'secondNum'\n");
            }

            switch (operation)
            {
                case "add":
                    result = number + number2; httpContext.Response.WriteAsync($"{result}");
                    break;
                case "subtract":
                    result = number - number2; httpContext.Response.WriteAsync($"{result}");
                    break;
                case "multiply":
                    result = number * number2; httpContext.Response.WriteAsync($"{result}");
                    break;
                case "division":
                    result = number / number2; httpContext.Response.WriteAsync($"{result}");
                    break;
                case "mod":
                    result = number % number2; httpContext.Response.WriteAsync($"{result}");
                    break;
                default:
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'operation'");
                    break;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OperationExtensions
    {
        public static IApplicationBuilder UseOperation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Operation>();
        }
    }
}
