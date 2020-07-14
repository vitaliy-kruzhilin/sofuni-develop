using System.Reflection;
using RentVacation.Dealers.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace RentVacation.Dealers.Data
{
    public class DealersDbContext : DbContext
    {
        public DealersDbContext(DbContextOptions<DealersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apartament> Apartaments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}