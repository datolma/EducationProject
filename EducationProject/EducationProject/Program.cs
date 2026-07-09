using EducationProject.API.DTO;
using EducationProject.API.Models;  
using EducationProject.API.Validators;
using EducationProject.Core.Application.Absractions;
using EducationProject.Core.Application.Services;
using EducationProject.Infrastructure;
using FluentValidation; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ⬇️ ВСЕ РЕГИСТРАЦИИ ДО Build() ⬇️
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IGoodRepositories, GoodRepositories>();
builder.Services.AddScoped<EducationService>();

builder.Services.AddScoped<IValidator<CreateGoodDTO>, CreateGoodValidator>();
builder.Services.AddScoped<IValidator<UpdateGoodDTO>, UpdateGoodValidator>();
builder.Services.AddScoped<IValidator<ResponseGoodDTO>, ResponseGoodValidator>();

var app = builder.Build();  // ← Build() ТОЛЬКО ПОСЛЕ ВСЕХ регистраций

// ⬇️ Миграции ПОСЛЕ Build() ⬇️
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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