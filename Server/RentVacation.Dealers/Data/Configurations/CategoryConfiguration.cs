﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentVacation.Dealers.Data.Models;

using static RentVacation.Common.Data.DataConstants.Common;
using static RentVacation.Dealers.Data.DataConstants.Category;

namespace RentVacation.Dealers.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
