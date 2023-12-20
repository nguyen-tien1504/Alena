using System;
using Alena.Services;
using Google.Cloud.Storage.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\Nguyen Tien\source\repos\Alena\test-6daef-firebase-adminsdk-4mdx8-ab0df52e7c.json");

// Add services to the container.

// product service
builder.Services.AddScoped<IProductService, ProductService>();

// db context servicw 
builder.Services.AddDbContext<DataContext>(options =>
{
    string connectstring = builder.Configuration.GetConnectionString("AlenaShop");
    options.UseSqlServer(connectstring);
});

builder.Services.AddSingleton<IFirestoreService>(
    s => new FirestoreService(StorageClient.Create())
);
// session 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
    cfg =>
    {
        cfg.Cookie.Name = "Alena123";
        cfg.IdleTimeout = new TimeSpan(0, 30, 0);
        cfg.Cookie.HttpOnly = true;
        cfg.Cookie.IsEssential = true;
    });

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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "Admin",
    pattern: "Area/{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
