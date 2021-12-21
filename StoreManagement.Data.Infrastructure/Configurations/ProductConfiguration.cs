using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain;

namespace StoreManagement.Data.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasOne(m => m.Brand);

            builder
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);

            builder
                .HasOne(m => m.Category);

            builder
                .HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.CategoryId);

            builder
                .ToTable("Products");
        }
    }
}
