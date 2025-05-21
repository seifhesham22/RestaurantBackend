
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Infrastructure;
using Restaurant.Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RestaurantDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Default"))); // DB configuration
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<RestaurantDbContext>().AddDefaultTokenProviders(); // Identity Configuration
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
