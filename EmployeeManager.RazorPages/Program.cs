using EmployeeManager.RazorPages.Models;
using EmployeeManager.RazorPages.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AddPageRoute("/EmployeeManager/List", "");
    });

//builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));
builder.Services.AddDbContext<EmployeeManager.RazorPages.Security.AppIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Security/SignIn";
    options.AccessDeniedPath = "/Security/AccessDenied";
});


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

app.UseAuthentication();

app.UseAuthorization();


app.MapRazorPages();

app.Run();
