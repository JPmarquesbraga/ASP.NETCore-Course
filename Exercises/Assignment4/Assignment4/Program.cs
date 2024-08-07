using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    var isEmpty = false;

    if (!context.Request.Query.ContainsKey("firstNumber"))
    {
        isEmpty = true;
    }   

    if (!context.Request.Query.ContainsKey("secondNumber"))
    {  
        isEmpty = true;
    }
    
    if (!context.Request.Query.ContainsKey("operation"))
    {
        isEmpty = true;
    }

    if(isEmpty)
    {
        context.Response.StatusCode = 400;
        if (!context.Request.Query.ContainsKey("firstNumber"))
        {
            context.Response.WriteAsync("invalid input for firstNumber\n");
        }

        if (!context.Request.Query.ContainsKey("secondNumber"))
        {
            context.Response.WriteAsync("invalid input for secondNumber\n");
        }

        if (!context.Request.Query.ContainsKey("operation"))
        {
            context.Response.WriteAsync("invalid input for operation");
        }
        return;
    }

    var firstNum = context.Request.Query["firstNumber"];
    var secondNum = context.Request.Query["secondNumber"];
    var operation = context.Request.Query["operation"];
    var result = 0;
     
    if (!isEmpty)
    {
        context.Response.StatusCode = 400;
        if (string.IsNullOrEmpty(context.Request.Query["firstNumber"]))
        {
            context.Response.WriteAsync($"Invalid input for 'firstNum'\n");
        }

        if (string.IsNullOrEmpty(context.Request.Query["secondNumber"]))
        {
            context.Response.WriteAsync($"Invalid input for 'secondNum'\n");
        }

        if (string.IsNullOrEmpty(context.Request.Query["operation"]))
        {
            context.Response.WriteAsync($"Invalid input for 'operation'\n");
        }
        return ;
    }

    
    if (int.TryParse(firstNum, out int number))
    {
        Console.WriteLine($"O número convertido é: {number}");
    } else
    {
        Console.WriteLine($"A string '{firstNum}' não pôde ser convertida para um número inteiro.");
        context.Response.WriteAsync($"Invalid input for 'firstNum'\n");
    }
    

    if (int.TryParse(secondNum, out int number2))
    {
        Console.WriteLine($"O número convertido é: {number2}");
    } else
    {
        Console.WriteLine($"A string '{secondNum}' não pôde ser convertida para um número inteiro.");
        context.Response.WriteAsync($"Invalid input for 'secondNum'\n");      
    }

    switch (operation)
    {
        case "add": result = number + number2; context.Response.WriteAsync($"{result}");
            break;
        case "subtract": result = number - number2; context.Response.WriteAsync($"{result}");
            break;
        case "multiply": result = number * number2; context.Response.WriteAsync($"{result}");
            break;
        case "division": result = number / number2; context.Response.WriteAsync($"{result}");
            break;
        case "mod": result = number % number2; context.Response.WriteAsync($"{result}");
            break;
        default:
            context.Response.StatusCode = 400;
            context.Response.WriteAsync("Invalid input for 'operation'");
            break;
    }
    
});

app.Run();
