using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Configurations
{
    internal class FullfillmentStatusConfiguration : IEntityTypeConfiguration<FullfillmentStatus>
    {
        public void Configure(EntityTypeBuilder<FullfillmentStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.Fullfillment_Status);
        }
    }
}
