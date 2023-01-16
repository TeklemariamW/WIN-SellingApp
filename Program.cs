using Microsoft.EntityFrameworkCore;
using WIN_sellingApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();

// Access-Control-Allow-Origin
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "Customers",
                        policy =>
                        {
                            policy.WithOrigins("https://localhost:44464")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
