using Assignment4_middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseVerifyerror();

app.UseOperation();

app.Run();
