using Microsoft.EntityFrameworkCore;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;
using System.Reflection;
using MyAspNetCore.Web.Filters;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritaban? ba?lant?s?
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //dbContext.products 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

//builder.Services.AddSingleton<IHelper, Helper>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<NotFoundFilter>();

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

//blog/abc => blog controller > article action method ?al??s?n
//blog/dd  => blog controller > article action method ?al??s?n

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

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
