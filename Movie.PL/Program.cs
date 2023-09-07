using Microsoft.EntityFrameworkCore;
using Movie.BL.Interfaces;
using Movie.BL.Mapper;
using Movie.BL.Repositories;
using Movie.DAL.Database;

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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
