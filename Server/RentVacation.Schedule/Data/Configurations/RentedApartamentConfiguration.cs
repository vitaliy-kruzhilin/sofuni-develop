using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Schedule.Data.Models;

namespace RentVacation.Schedule.Data.Configurations
{
    public class RentedApartamentConfiguration : IEntityTypeConfiguration<RentedApartament>
    {
        public void Configure(EntityTypeBuilder<RentedApartament> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Information)
                .IsRequired();
        }
    }
}
