using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ejercicio02ASP.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Ejercicio02ASPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ejercicio02ASPContext") ?? throw new InvalidOperationException("Connection string 'Ejercicio02ASPContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
