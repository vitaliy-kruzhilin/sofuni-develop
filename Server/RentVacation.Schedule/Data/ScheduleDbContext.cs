using Microsoft.EntityFrameworkCore;
using RentVacation.Schedule.Data.Models;
using System.Reflection;

namespace RentVacation.Schedule.Data
{
    public class ScheduleDbContext: DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<RentedApartament> RentedApartaments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}