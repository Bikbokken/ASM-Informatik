using ASM.Shared.Repositories;
using ASM.Shared.Services;
using ASM.Web.Components;
using ASM.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the ASM.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AssetRepository>();
builder.Services.AddScoped<AssetService>();

builder.Services.AddScoped<AssetCategoryRepository>();
builder.Services.AddScoped<AssetCategoryService>();

// Location
builder.Services.AddScoped<LocationRepository>();
builder.Services.AddScoped<LocationService>();

// User
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();


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
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ASM.Shared._Imports).Assembly);

app.Run();
