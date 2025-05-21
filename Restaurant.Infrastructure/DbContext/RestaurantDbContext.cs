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
    }
}
