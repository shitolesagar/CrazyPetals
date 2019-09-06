using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrazyPetals.Repository.Configurations
{
    internal class OrderSummaryConfiguration : IEntityTypeConfiguration<OrderSummary>
    {
        public void Configure(EntityTypeBuilder<OrderSummary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.AppId).HasMaxLength(30);

            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.OrderSummaries).HasForeignKey(x => x.ApplicationUserId);
            builder.HasOne(x => x.UserAddress).WithMany(x => x.OrderSummaries).HasForeignKey(x => x.UserAddressId);
        }
    }
}
