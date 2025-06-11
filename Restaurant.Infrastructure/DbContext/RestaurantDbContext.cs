using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.DbContext
{
    public class RestaurantDbContext : IdentityDbContext<ApplicationUser , ApplicationRole , Guid> 
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish>  Dishes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<DishCart> DishesCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Dish>()
                   .Property(d => d.Category)
                   .HasConversion<int>();
            builder.Entity<Dish>().ToTable("Dishes");

            string dishJson = System.IO.File.ReadAllText("C:\\Users\\user\\Source\\Repos\\RestaurantBackend\\Restaurant.Infrastructure\\Dishes.Json");
            List<Dish>? dishList = System.Text.Json.JsonSerializer.Deserialize<List<Dish>>(dishJson);

            foreach (Dish dish in dishList)
            {
                builder.Entity<Dish>().HasData(dish);
            }
        }
    }
}
