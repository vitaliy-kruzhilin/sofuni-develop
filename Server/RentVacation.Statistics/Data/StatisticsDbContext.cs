using Microsoft.EntityFrameworkCore;
using RentVacation.Statistics.Data.Models;
using System.Reflection;

namespace RentVacation.Statistics.Data
{
    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApartamentView> ApartamentViews { get; set; }

        public DbSet<TotalStatistics> TotalStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
