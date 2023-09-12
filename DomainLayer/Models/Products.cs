namespace DomainLayer.Models
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductNumber { get; set; } = 0;
        public string? Photos { get; set; }
        public int Price { get; set; } = 0;
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Cart> Cart { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
