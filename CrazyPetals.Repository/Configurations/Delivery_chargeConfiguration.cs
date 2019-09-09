using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Configurations
{
    internal class Delivery_chargeConfiguration : IEntityTypeConfiguration<Delivery_charge>
    {
        public void Configure(EntityTypeBuilder<Delivery_charge> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.Min);
            builder.Property(x => x.Max);
            builder.Property(x => x.AppId);
            builder.Property(x => x.DeliveryCharge);
            builder.Property(x => x.CreatedDate);
        }
    }
}
