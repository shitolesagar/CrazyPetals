using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrazyPetals.Repository.Configurations
{
    internal class FilterProductConfiguration : IEntityTypeConfiguration<FilterProduct>
    {
        public void Configure(EntityTypeBuilder<FilterProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.HasOne(x => x.Filter).WithMany(x => x.FilterProducts).HasForeignKey(x => x.FilterId);
            builder.HasOne(x => x.Product).WithMany(x => x.FilterProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
