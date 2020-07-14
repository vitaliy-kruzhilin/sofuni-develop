using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Dealers.Data.Models;

using static RentVacation.Common.Data.DataConstants.Common;
using static RentVacation.Dealers.Data.DataConstants.Apartament;

namespace RentVacation.Dealers.Data.Configurations
{
    internal class ApartamentConfiguration : IEntityTypeConfiguration<Apartament>
    {
        public void Configure(EntityTypeBuilder<Apartament> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Information)
                .IsRequired()
                .HasMaxLength(MaxInformationLength);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.IsAvailable)
                .IsRequired();

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Apartaments)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.Options, options =>
                {
                    options.WithOwner();

                    options
                        .Property(op => op.NumberOfBeds)
                        .IsRequired();

                    options
                        .Property(op => op.HasClimateControl)
                        .IsRequired();

                    options
                        .Property(op => op.Floor)
                        .IsRequired();
                });
        }
    }
}
