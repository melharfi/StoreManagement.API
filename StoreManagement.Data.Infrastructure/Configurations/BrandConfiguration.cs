using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain;

namespace StoreManagement.Data.Infrastructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .ToTable("Brands");
        }
    }
}
