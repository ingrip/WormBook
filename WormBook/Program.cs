using Microsoft.EntityFrameworkCore;
using WormBook.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregar el DbContext con Oracle
builder.Services.AddDbContext<MiContexto>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("MiConexionOracle")));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); // necesario para @inject

// Otros servicios...
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();

app.MapControllers();
app.Run();

