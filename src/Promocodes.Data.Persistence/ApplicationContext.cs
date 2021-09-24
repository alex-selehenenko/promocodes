using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Persistence.Configurations;

namespace Promocodes.Data.Persistence
{
    public class ApplicationContext : DbContext
    {
        private const string DefaultConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=PromocodesDb;Trusted_Connection=true";

        public DbSet<Category> Categories { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration())
                        .ApplyConfiguration(new ShopConfiguration())
                        .ApplyConfiguration(new OfferConfiguration())
                        .ApplyConfiguration(new ReviewConfiguration())
                        .ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(DefaultConnectionString);
            }
        }
    }
}
