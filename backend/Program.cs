using backend.DB;
using backend.Services;
using backend.Services.Impl;
using backend.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add database services to the container.
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<ICategoryService, DbCategoryService>();
builder.Services.AddScoped<IProductService,DbProductService>();
builder.Services.AddScoped<IUserservice, DBUserService>();
builder.Services.AddScoped<ITokenService, DbTokenService>();

//Configuration for AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add services for the Identity
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();

        if (dbContext is not null)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}

app.UseHttpsRedirection();

//Adding Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
