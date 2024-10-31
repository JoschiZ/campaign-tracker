using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;
using SeasonOfGhosts.Components;
using SeasonOfGhosts.Db;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog((provider, configuration) =>
{
    configuration
        .ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddBlazoredLocalStorage();

builder.Configuration
    .AddJsonFile("secret.appsettings.json", optional: true)
    .AddJsonFile($"secret.appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


// Add MudBlazor services
builder.Services.AddMudServices(x =>
{
    x.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
});
builder.Services.AddMudExtensions();
builder.Services.AddDbContextFactory<SeasonContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
