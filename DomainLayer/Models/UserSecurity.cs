namespace DomainLayer.Models
{
    public class UserSecurity : BaseEntity
    {
        public int UserSecurityId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string VerificationCode { get; set; }
    }
}
