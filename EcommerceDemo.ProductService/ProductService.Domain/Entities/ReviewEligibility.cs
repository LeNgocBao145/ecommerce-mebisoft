namespace ProductService.Domain.Entities
{
    public class ReviewEligibility
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
