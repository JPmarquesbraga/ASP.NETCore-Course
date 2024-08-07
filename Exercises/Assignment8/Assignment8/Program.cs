var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

var countries = new Dictionary<int, string>();
countries.Add(1, "United States");
countries.Add(2, "Canada");
countries.Add(3, "United Kingdon");
countries.Add(4, "India");
countries.Add(5, "Japan");

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints => 
{
    endpoints.MapGet("countries", async context =>
    {
        var allCountries = string.Join("\n", countries.Select(country => $"{country.Key}, {country.Value}"));
        await context.Response.WriteAsync(allCountries);
       // await context.Response.WriteAsync(countries[1]);
    });

    endpoints.Map("countries/{countryId:int:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;
        context.Response.WriteAsync("The CountryID should be between 1 and 100");
        return;
    });

    endpoints.Map("countries/{countryId}", async context =>
    {
        int countryid = Convert.ToInt32(context.Request.RouteValues["countryId"]);
        if (countries.ContainsKey(countryid))
        {
            context.Response.WriteAsync(countries[countryid]);
            return;
        }
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();
