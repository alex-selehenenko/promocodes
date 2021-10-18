using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Persistence.Configurations;
using Promocodes.Data.Persistence.SeedData;
using System;

namespace Promocodes.Data.Persistence
{
    public class PromocodesDbContext : DbContext, IUnitOfWork
    {
        private const string DefaultConnectionString = "Data Source=(localdb)\\MSSQLLocalDb;Database=PromocodesDb";

        public DbSet<Category> Categories { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ShopAdmin> ShopAdmins { get; set; }

        public PromocodesDbContext()
        {
        }

        public PromocodesDbContext(DbContextOptions<PromocodesDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration())
                        .ApplyConfiguration(new ShopConfiguration())
                        .ApplyConfiguration(new OfferConfiguration())
                        .ApplyConfiguration(new ReviewConfiguration())
                        .ApplyConfiguration(new UserConfiguration())
                        .ApplyConfiguration(new CustomerConfiguration())
                        .ApplyConfiguration(new ShopAdminConfiguration());

            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(DefaultConnectionString);                
            }
        }
    }
}
