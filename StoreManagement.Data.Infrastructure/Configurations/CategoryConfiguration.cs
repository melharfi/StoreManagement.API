using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain;

namespace StoreManagement.Data.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .ToTable("Categories");
        }
    }
}
