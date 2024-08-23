using Lab3_AspNet_EF.Data;
using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages support

// Configure the DbContext with a connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register your repositories as scoped services
builder.Services.AddScoped<IBaseRepository<Subscriber>, BaseRepository<Subscriber>>();
builder.Services.AddScoped<IBaseRepository<Call>, BaseRepository<Call>>();
builder.Services.AddScoped<IBaseRepository<City>, BaseRepository<City>>();
builder.Services.AddScoped<IBaseRepository<Phone>, BaseRepository<Phone>>();
builder.Services.AddScoped<IBaseRepository<Tariff>, BaseRepository<Tariff>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map controller routes for Web API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages routes
app.MapRazorPages(); // Enable Razor Pages routing

app.Run();