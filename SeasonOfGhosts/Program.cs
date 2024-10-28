using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MudExtensions.Services;
using SeasonOfGhosts.Components;
using SeasonOfGhosts.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .AddJsonFile("secret.appsettings.json", optional: true)
    .AddJsonFile($"secret.appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


// Add MudBlazor services
builder.Services.AddMudServices();
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
