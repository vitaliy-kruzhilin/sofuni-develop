using System.Reflection;
using RentVacation.Dealers.Data.Models;
using Microsoft.EntityFrameworkCore;
using RentVacation.Common.Data;

namespace RentVacation.Dealers.Data
{
    public class DealersDbContext : MessageDbContext
    {
        public DealersDbContext(DbContextOptions<DealersDbContext> options): base(options)
        {
        }

        public DbSet<Apartament> Apartaments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}