namespace ProductService.Domain.Entities
{
    public class ProductReview
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
