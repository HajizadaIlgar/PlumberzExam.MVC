using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plumberz.Core.Entities.Account;
using Plumberz.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlumberzDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MySQL"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Lockout.AllowedForNewUsers = false;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}).AddDefaultTokenProviders().AddEntityFrameworkStores<PlumberzDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
