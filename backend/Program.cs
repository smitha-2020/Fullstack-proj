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
using backend.src.Repository.RoleRepository;
using backend.src.Services.RoleService;
using backend.src.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

builder.WebHost.UseKestrel(options =>
    options.ListenLocalhost(5001, options => options.UseHttps())
);

builder.Services.AddCors(options =>
  {
      options.AddPolicy("CorsPolicy",
          builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
  });



// Add database services to the container.
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuration for AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Dependency Injection

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

builder.Services.AddScoped<IRoleRepo, RoleRepo>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddTransient<ErrorHandlerMiddleware>();

//Add Identity
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>(
    //     options =>
    // {
    //     options.Password.RequiredLength = 6;
    //     options.Password.RequireDigit = false;
    //     options.Password.RequireLowercase = false;
    // }
    )
    .AddEntityFrameworkStores<AppDBContext>();


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

var app = builder.Build();

//ExceptionHandler Middleware
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
//Adding Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
