﻿using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrazyPetals.Repository.Configurations
{
    internal class OrderSummaryConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.Orders).HasForeignKey(x => x.ApplicationUserId);
            builder.HasOne(x => x.UserAddress).WithMany(x => x.Orders).HasForeignKey(x => x.UserAddressId);
        }
    }
}
