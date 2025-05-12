using ASM.Shared.Models;
using ASM.Shared.Repositories;
using ASM.Shared.Services;
using ASM.Web.Components;
using ASM.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using ASM.Web.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the ASM.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityDataContext>();

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


builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/login";  // Set the login page route
        options.AccessDeniedPath = "/access-denied";  // Set the access-denied page route
    });

// Add authorization services
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
// Replace the registration of AuthenticationStateProvider with the correct implementation for Blazor Server
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAuthentication();  // Enable Authentication middleware
app.UseAuthorization();   // Enable Authorization middleware


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ASM.Shared._Imports).Assembly);

app.Run();
