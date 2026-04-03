using PromotionService.Domain.Enums;

namespace PromotionService.Domain.Entities
{
    public class Coupon
    {
        public Guid Code { get; set; }
        public DiscountType Type { get; set; }
        public decimal Value { get; set; }
        public decimal MinOrderValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsageLimit { get; set; }
    }
}
