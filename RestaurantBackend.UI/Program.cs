using IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure;
using Restaurant.Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DeliveryApiInternationalContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Default"))); // DB configuration
builder.Services.AddIdentity<AspNetUser, AspNetRole>().AddEntityFrameworkStores<DeliveryApiInternationalContext>().AddDefaultTokenProviders(); // Identity Configuration
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
