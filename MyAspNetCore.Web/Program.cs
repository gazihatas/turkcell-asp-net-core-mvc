using Microsoft.EntityFrameworkCore;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritabaný baðlantýsý
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //dbContext.products 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

//builder.Services.AddSingleton<IHelper, Helper>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

//blog/abc => blog controller > article action method çalýþsýn
//blog/dd  => blog controller > article action method çalýþsýn

//app.MapControllerRoute(
//    name: "pages",
//    pattern: "blog/{*article}",
//    defaults:new {controller="Blog", action="Article"});


//app.MapControllerRoute(
//    name: "article",
//    pattern: "{controller=Blog}/{action=Article}/{page}/{id}");

//app.MapControllerRoute(
//    name: "pages",
//    pattern: "{controller}/{action}/{page}/{pageSize}");

//app.MapControllerRoute(
//    name: "getbyid",
//    pattern: "{controller}/{action}/{productid}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
