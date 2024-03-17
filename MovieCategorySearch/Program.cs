using Merino;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MovieCategorySearch.Infrastructure.Data;

//アプリケーション初期化
WebApplicationBuilder builder = BootStrap.BuildWebApplication(args);

//認証
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); //有効期限
        options.SlidingExpiration = true; //有効期限を延長
        options.LoginPath = "/Authentication/Login";
        options.AccessDeniedPath = "/Authentication/AccessDenied";
    });


//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//});

WebApplication app = BootStrap.CreateWebApplication(builder);

app.UseAuthentication();
app.UseAuthorization();

//テストデータ
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

BootStrap.RunWebApplication(app);