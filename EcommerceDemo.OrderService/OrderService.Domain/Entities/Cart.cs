namespace OrderService.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppliedCouponCode { get; set; }
        public decimal CouponDiscount { get; set; }
        public decimal RankDiscount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
