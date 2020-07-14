using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Statistics.Data.Models;

namespace RentVacation.Statistics.Data.Configurations
{
    public class ApartamentViewConfiguration : IEntityTypeConfiguration<ApartamentView>
    {
        public void Configure(EntityTypeBuilder<ApartamentView> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasIndex(v => v.ApartamentId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}
