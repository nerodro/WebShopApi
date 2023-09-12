namespace DomainLayer.Models
{
    public class Cart : BaseEntity
    {
        public long UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        //public Cart()
        //{
        //    UserProfile = new List<UserProfile>();
        //    Products = new List<Products>();
        //}
        public long ProductsId { get; set; }
        public string ProductName { get; set; }
        public virtual Products Products { get; set; }
        public int CountProduct { get; set; } = 0;
        public int SummaryPrice { get; set; } = 0;
    }
}
