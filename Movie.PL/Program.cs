using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Movie.BL.Interfaces;
using Movie.BL.Mapper;
using Movie.BL.Repositories;
using Movie.DAL.Database;
using Movie.PL.Language;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Connection Database
var ConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");
builder.Services.AddDbContext<ApllicationDbContext>(optin => optin.UseSqlServer(ConnectionString));
#endregion

#region Dependency Injection
builder.Services.AddScoped<IMovies, MoviesRepo>();
builder.Services.AddScoped<IGeners, GenersRepo>();
#endregion

#region Auto Mapper
builder.Services.AddAutoMapper(option => option.AddProfile(new DomainProfile()));
#endregion

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(Lang));
    }); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
#region Language
var supportedCultures = new[] {
                      new CultureInfo("ar-EG"),
                      new CultureInfo("en-US"),
                };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
});
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
