

using Microsoft.EntityFrameworkCore;
using proyectoDAL;
using Microsoft.EntityFrameworkCore;
using proyectoBL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductoBL>();
builder.Services.AddScoped<ProductoDAL>();
builder.Services.AddScoped<CategoriaBL>();
builder.Services.AddScoped<CategoriaDAL>();

var conString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<SysProductoDBContext>(
    options => options.UseMySql(conString, ServerVersion.AutoDetect(conString))
);


// Add services to the container.
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