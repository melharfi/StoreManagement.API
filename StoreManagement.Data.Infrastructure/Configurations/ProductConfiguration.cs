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
                .Property(m => m.ProductBrand)
                .IsRequired();

            builder
                .HasOne(m => m.ProductBrand)
                .WithMany()
                .HasForeignKey(m => m.ProductBrandId);

            builder
                .Property(m => m.ProductCategory)
                .IsRequired();

            builder
                .HasOne(m => m.ProductCategory)
                .WithMany()
                .HasForeignKey(m => m.ProductCategoryId);


            builder
                .ToTable("Products");
        }
    }
}
