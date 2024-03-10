using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Repositories.services;
using StudentManagement.Models.Repositories;
using StudentManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<StudentContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));

builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
app.MapControllerRoute(
    name: "Student",
    pattern: "{controller=Student}/{action=Create}/{id?}");
app.MapControllerRoute(
    name: "School",
    pattern: "{controller=School}/{action=Create}/{id?}");

app.Run();
