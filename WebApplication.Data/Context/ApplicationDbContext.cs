using System;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.DataModels.Configurations;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Infrastructure;

namespace WebApplication.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<ConfigurationType> ConfigurationTypes { get; set; }
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }

        public DbSet<Basket> BasketItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>()
                .HasOne<Brand>(e => e.Brand)
                .WithMany(e => e.Laptops)
                .HasForeignKey(e => e.BrandId)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .HasMany<Laptop>(e => e.Laptops)
                .WithOne(e => e.Brand)
                .IsRequired();

            modelBuilder.Entity<ConfigurationItem>()
                .HasOne<ConfigurationType>(e => e.ConfigurationItemType)
                .WithMany(e => e.ConfigurationItems)
                .HasForeignKey(e => e.ConfigurationTypeId)
                .IsRequired();

            modelBuilder.Entity<ConfigurationType>()
                .Property(e => e.TypeName)
                .HasConversion(v => v.ToString(),
                    v => (ConfigurationTypeEnum) Enum.Parse(typeof(ConfigurationTypeEnum), v));

            modelBuilder.Entity<ConfigurationType>()
                .HasMany<ConfigurationItem>(e => e.ConfigurationItems)
                .WithOne(e => e.ConfigurationItemType)
                .IsRequired();

            modelBuilder.Entity<LaptopConfiguration>()
                .HasKey(e => new {e.LaptopId, e.ConfigurationItemId});

            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne<ConfigurationItem>(e => e.ConfigurationItem)
                .WithMany(e => e.LaptopConfigurations)
                .HasForeignKey(e => e.ConfigurationItemId);

            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne<Laptop>(e => e.Laptop)
                .WithMany(e => e.LaptopConfiguration)
                .HasForeignKey(e => e.LaptopId);

            modelBuilder.Entity<Basket>()
                .HasOne(e => e.Laptop)
                .WithOne(e => e.Basket)
                .HasForeignKey<Basket>(b => b.LaptopId);

            modelBuilder.Entity<Brand>().HasData(new[]
            {
                new Brand {Id = 1, Name = "Dell", Cost = 349.87M},
                new Brand {Id = 2, Name = "Toshiba", Cost = 345.67M},
                new Brand {Id = 3, Name = "HP", Cost = 456.76M}
            });

            modelBuilder.Entity<ConfigurationType>().HasData(new[]
            {
                new ConfigurationType {Id = 1, TypeName = ConfigurationTypeEnum.Ram},
                new ConfigurationType {Id = 2, TypeName = ConfigurationTypeEnum.Hdd},
                new ConfigurationType {Id = 3, TypeName = ConfigurationTypeEnum.Color},
                new ConfigurationType {Id = 4, TypeName = ConfigurationTypeEnum.Cpu}
            });

            modelBuilder.Entity<ConfigurationItem>().HasData(new[]
            {
                new ConfigurationItem {Id = 1, Name = "8GB", Cost = 45.67M, ConfigurationTypeId = 1},
                new ConfigurationItem {Id = 2, Name = "16GB", Cost = 87.88M, ConfigurationTypeId = 1},
                new ConfigurationItem {Id = 3, Name = "500GB", Cost = 123.34M, ConfigurationTypeId = 2},
                new ConfigurationItem {Id = 4, Name = "1TB", Cost = 200M, ConfigurationTypeId = 2},
                new ConfigurationItem {Id = 5, Name = "Red", Cost = 50.76M, ConfigurationTypeId = 3},
                new ConfigurationItem {Id = 6, Name = "Blue", Cost = 34.56M, ConfigurationTypeId = 3}
            });

            modelBuilder.Entity<Laptop>().HasData(new[]
            {
                new Laptop {Id = 1, Name = "Laptop 1", BrandId = 1},
                new Laptop {Id = 2, Name = "Laptop 2", BrandId = 2}
            });

            modelBuilder.Entity<LaptopConfiguration>().HasData(new[]
            {
                new LaptopConfiguration {LaptopId = 1, ConfigurationItemId = 1},
                new LaptopConfiguration {LaptopId = 1, ConfigurationItemId = 3},
                new LaptopConfiguration {LaptopId = 1, ConfigurationItemId = 5},

                new LaptopConfiguration {LaptopId = 2, ConfigurationItemId = 1},
                new LaptopConfiguration {LaptopId = 2, ConfigurationItemId = 3},
                new LaptopConfiguration {LaptopId = 2, ConfigurationItemId = 5}
            });
        }
    }
}