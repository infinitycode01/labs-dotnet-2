using Lab3_AspNet_EF.Data;
using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IBaseRepository<Subscriber>, BaseRepository<Subscriber>>();
builder.Services.AddScoped<IBaseRepository<Call>, BaseRepository<Call>>();
builder.Services.AddScoped<IBaseRepository<City>, BaseRepository<City>>();
builder.Services.AddScoped<IBaseRepository<Phone>, BaseRepository<Phone>>();
builder.Services.AddScoped<IBaseRepository<Tariff>, BaseRepository<Tariff>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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