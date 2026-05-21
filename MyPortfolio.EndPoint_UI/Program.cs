using MyPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Application.Contract;
using MyPortfolio.Application.Services;
using MyPortfolio.Application.Services.Abouts;
using MyPortfolio.Application.Services.Profile;
using MyPortfolio.Application.Services.Skill;
using MyPortfolio.Application.Services.WorkExperience;
using MyPortfolio.Application.Services.Education;
using MyPortfolio.Application.Services.Language;
using MyPortfolio.Application.Services.ContactMessage;



var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IWorkExperienceService, WorkExperienceService>();

builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddScoped<ILanguageService, LanguageService>();

builder.Services.AddScoped<IContactMessageService, ContactMessageService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IContext, AppDbContext>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ISkillService, SkillService>();


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

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
