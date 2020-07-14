using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Dealers.Data.Models;

using static RentVacation.Common.Data.DataConstants.Common;
using static RentVacation.Dealers.Data.DataConstants.Dealer;

namespace RentVacation.Dealers.Data.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(MaxPhoneNumberLength);

            builder
                .Property(d => d.UserId)
                .IsRequired();

            builder
                .HasMany(d => d.Apartaments)
                .WithOne(c => c.Dealer)
                .HasForeignKey(c => c.DealerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
