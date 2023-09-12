namespace DomainLayer.Models
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        //public virtual User User { get; set; }
        public virtual List<User> User { get; set; }
        public Role()
        {
            User = new List<User>();
        }
        //public virtual UserProfile UserProfile { get; set; }
    }
}
