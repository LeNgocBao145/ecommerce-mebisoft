using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Stock).HasColumnType("int").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnType("bit").HasDefaultValue(false);
            builder.HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("ProductCategories"));
        }
    }
}
