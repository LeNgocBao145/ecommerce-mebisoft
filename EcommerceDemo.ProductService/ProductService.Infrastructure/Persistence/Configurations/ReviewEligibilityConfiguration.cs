using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Persistence.Configurations
{
    public class ReviewEligibilityConfiguration : IEntityTypeConfiguration<ReviewEligibility>
    {
        public void Configure(EntityTypeBuilder<ReviewEligibility> builder)
        {
            builder.HasKey(re => new { re.UserId, re.ProductId });
            builder.ToTable("ReviewEligibilities");
        }
    }
}
