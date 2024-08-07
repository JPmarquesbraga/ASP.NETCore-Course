using Assignment5.Middleware;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Useauthentication();

app.UseVerifyEmail();

app.Run();
