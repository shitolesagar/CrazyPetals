﻿using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrazyPetals.Repository.Configurations
{
    internal class SmtpMailConfiguration : IEntityTypeConfiguration<SmtpMail>
    {
        public void Configure(EntityTypeBuilder<SmtpMail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.AppId).HasMaxLength(30);
        }
    }
}
