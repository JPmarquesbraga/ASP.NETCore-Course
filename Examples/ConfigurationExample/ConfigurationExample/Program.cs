using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherApiOption>(builder.Configuration.GetSection("weatherapi"));

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
/*
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["myKEY"] + "\n");

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");

        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n");
    });
});
*/
app.MapControllers();
app.Run();
