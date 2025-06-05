using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.AutoMapperProfiles;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.Services;
using Restaurant.Core.ServicesContracts;
using Restaurant.Infrastructure;
using Restaurant.Infrastructure.DbContext;
using Restaurant.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RestaurantDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Default"))); // DB configuration
builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<RestaurantDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, RestaurantDbContext, Guid>>() // Identity Configuration
    .AddRoleStore<RoleStore<ApplicationRole, RestaurantDbContext, Guid>>();
builder.Services.AddScoped<IDishRepository , DishRepository>();
builder.Services.AddScoped<ICartRepository , CartRepository>();
builder.Services.AddScoped<IOrderRepository , OrderRepository>();
builder.Services.AddScoped<IRatingRepository , RatingRepository>();
builder.Services.AddScoped<IDishService , DishService>();
builder.Services.AddScoped<ICartService , CartService>();
builder.Services.AddScoped<IRatingService , RatingService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProfileService , ProfileService>();
builder.Services.AddScoped<ITokenService , TokenService>();
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<RegisterUseCase>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DishCartProfile).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
