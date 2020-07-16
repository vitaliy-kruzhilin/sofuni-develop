using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Schedule.Data.Models;

namespace RentVacation.Schedule.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Comment)
                .IsRequired();

            builder
                .HasOne(f => f.Reservation)
                .WithOne()
                .HasForeignKey<Feedback>(f => f.ReservationId);
        }
    }
}
