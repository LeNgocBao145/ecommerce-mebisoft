using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Id).ValueGeneratedOnAdd();
            builder.Property(pr => pr.UserId).IsRequired();
            builder.Property(pr => pr.ProductId).IsRequired();
            builder.Property(pr => pr.Rating).HasColumnType("int").IsRequired();
            builder.Property(pr => pr.Comment).HasColumnType("nvarchar(200)");
            builder.ToTable("ProductReviews", t => t.HasCheckConstraint(
                "CK_Review_Rating",
                "[Rating] >= 1 AND [Rating] <= 5"
            ));

            builder.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
