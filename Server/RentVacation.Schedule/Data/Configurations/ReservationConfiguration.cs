using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Schedule.Data.Models;

namespace RentVacation.Schedule.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(r => r.Client)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.ClientId);

            builder
                .HasOne(r => r.RentedApartament)
                .WithMany(rc => rc.Reservations)
                .HasForeignKey(r => r.RentedApartamentId);
        }
    }
}
