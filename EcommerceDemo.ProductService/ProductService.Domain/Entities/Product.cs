namespace ProductService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Category> Categories { get; set; } = [];
        public ICollection<ProductReview> Reviews { get; set; } = [];
    }
}
