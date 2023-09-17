namespace DomainLayer.Models
{
    public class Company : BaseEntity
    {
        public string CompanyNamme { get; set; } = null!;
        public string CompanyIdentity { get; set; } = null;
       // public int StatusCompany { get; set; } = 0!;
        // public virtual Products Products { get; set; }
        public virtual List<Products> Products { get; set; }
        
        public Company()
        {
            Products = new List<Products>();
        }
    }
}
