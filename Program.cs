using Microsoft.AspNetCore.Authentication.Negotiate;
using WindowsLoginSample.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddScoped<DataController>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();
