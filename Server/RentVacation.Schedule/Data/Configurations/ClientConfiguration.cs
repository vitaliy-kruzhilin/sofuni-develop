using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Schedule.Data.Models;

namespace RentVacation.Schedule.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.PersonalId)
                .IsRequired();

            builder
                .Property(c => c.UserId)
                .IsRequired();
        }
    }
}
