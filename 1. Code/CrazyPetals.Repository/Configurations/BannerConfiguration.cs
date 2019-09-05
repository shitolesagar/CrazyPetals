using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrazyPetals.Repository.Configurations
{
    internal class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.AppId).HasMaxLength(30);

            builder.HasOne(x => x.Role).WithMany(x => x.ApplicationUsers).HasForeignKey(x => x.RoleId);
        }
    }
}
