using System;
using System.Collections.Generic;
using Entities;
using IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infrastructure.DbContext;

public partial class DeliveryApiInternationalContext : IdentityDbContext<AspNetUser, AspNetRole, Guid>
{
    public DeliveryApiInternationalContext()
    {
    }

    public DeliveryApiInternationalContext(DbContextOptions<DeliveryApiInternationalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishBasket> DishBaskets { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Delivery.Api.international;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<AspNetUser>().ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<AspNetRole>().ToTable("AspNetRoles", t => t.ExcludeFromMigrations());

        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AspNetUserClaims", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AspNetUserRoles", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AspNetUserLogins", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AspNetRoleClaims", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AspNetUserTokens", t => t.ExcludeFromMigrations());

        modelBuilder
            .Entity<AspNetRole>(
                entity =>
                {
                    entity
                        .HasIndex(e => e.NormalizedName, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    entity
                        .Property(e => e.Id)
                        .ValueGeneratedNever();

                    entity
                        .Property(e => e.Name)
                        .HasMaxLength(256);

                    entity
                        .Property(e => e.NormalizedName)
                        .HasMaxLength(256);
                }
            );

        modelBuilder
            .Entity<Dish>(
                entity =>
                {
                    entity.
                        Property(e => e.Id)
                        .ValueGeneratedNever();
                    entity
                        .Property(e => e.Price)
                        .HasColumnType("decimal(18, 2)");
                }
            );

        modelBuilder
            .Entity<DishBasket>(
                entity =>
                {
                    entity.HasIndex(e => e.DishId, "IX_DishBaskets_DishId");

                    entity.HasIndex(e => e.OrderId, "IX_DishBaskets_OrderId");

                    entity.HasIndex(e => e.UserId, "IX_DishBaskets_UserId");

                    entity.Property(e => e.Id).ValueGeneratedNever();

                    entity
                        .HasOne(d => d.Dish)
                        .WithMany(p => p.DishBaskets)
                        .HasForeignKey(d => d.DishId);

                    entity
                        .HasOne(d => d.Order)
                        .WithMany(p => p.DishBaskets)
                        .HasForeignKey(d => d.OrderId);

                    entity
                        .HasOne(d => d.User)
                        .WithMany(p => p.DishBaskets)
                        .HasForeignKey(d => d.UserId);
                }
            );

        modelBuilder
            .Entity<Order>(
                entity =>
                {
                    entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                    entity.Property(e => e.Id).ValueGeneratedNever();
                    entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                    entity
                        .HasOne(d => d.User)
                        .WithMany(p => p.Orders)
                        .HasForeignKey(d => d.UserId);
                }
            );

        modelBuilder
            .Entity<Rating>(
                entity =>
                {
                    entity.HasIndex(e => e.DishId, "IX_Ratings_DishId");

                    entity.HasIndex(e => e.UserId, "IX_Ratings_UserId");

                    entity.Property(e => e.Id).ValueGeneratedNever();

                    entity
                        .HasOne(d => d.Dish)
                        .WithMany(p => p.Ratings)
                        .HasForeignKey(d => d.DishId);

                    entity
                        .HasOne(d => d.User)
                        .WithMany(p => p.Ratings)
                        .HasForeignKey(d => d.UserId);
                }
            );

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
