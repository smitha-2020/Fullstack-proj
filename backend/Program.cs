using backend.src.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend.src.Services.CategoryService;
using backend.src.Services.ProductService;
using backend.src.Repository.CategoryRepository;
using backend.src.Repository.ProductRepository;
using backend.src.Repository.CartRepository;
using backend.src.Services.TokenService;
using backend.src.Services.CartService;
using backend.src.Repository;
using backend.src.Models;
using backend.src.Services;
using backend.src.Repository.ImageRepository;
using backend.src.Services.ImageService;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
    //options.ListenLocalhost(5000),
    options.ListenLocalhost(5001, options => options.UseHttps())
);

// Add database services to the container.
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        ValidAudience = builder.Configuration["jwt:Aud"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuration for AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency Injection
//builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IImageRepo, ImageRepo>();
builder.Services.AddScoped<IImageService, ImageService>();

//Add services for the Identity
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDBContext>();

var app = builder.Build();
//ExceptionHandler Middleware
app.UseHttpsRedirection();

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

//Adding Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
