using Merino;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MovieCategorySearch.Infrastructure.Data;

//アプリケーション初期化
WebApplicationBuilder builder = BootStrap.BuildWebApplication(args);

//認証
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Authentication/Login";
        options.AccessDeniedPath = "/Authentication/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});

WebApplication app = BootStrap.CreateWebApplication(builder);

//テストデータ
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;

   SeedData.Initialize(services);
}

BootStrap.RunWebApplication(app);