using Auto.Konfiguration.BApplication.BusinessLogic;
using Auto.Konfiguration.BApplication.Interface;
using Auto.Konfiguration.Blazor.Components;
using Auto.Konfiguration.Domain.Interfaces;
using Auto.Konfiguration.Infrastructure.Daten;
using Microsoft.EntityFrameworkCore;
using System.IO;
using MudBlazor.Services;
using Auto.Konfiguration.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// DATABASE
var dbPath = @"C:\Users\Volke\source\repos\Auto.Konfiguration\Auto.Konfiguration\carconfig.db";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<IAppDbContextService, AppDbContext>();
builder.Services.AddScoped<ICalculatePrice, CalculatePrice>();
builder.Services.AddScoped<ConfigStateService>();

//MudBlazor
builder.Services.AddMudServices();

// BLAZOR
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// DATABASE INITIALIZE
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();
    db.InsertDB();
}

// MIDDLEWARE
app.UseStaticFiles();
app.UseAntiforgery();  

// ROUTING
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();