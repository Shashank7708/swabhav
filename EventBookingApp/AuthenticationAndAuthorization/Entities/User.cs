using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Entities
{
    
    public interface IAudit
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
    public class LoginMaster : IAudit
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public RolesEnum role { get; set; }
    }
    public class UserRefreshToken
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Referesh_Token { get; set; }
        public DateTime Expiry { get; set; }
    }
    public enum RolesEnum
    {
        Admin,
        Audience,
        User

    }

}
