using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Configurations
{
    internal class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.AppId).HasMaxLength(30);

            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.ActivityLogs).HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
