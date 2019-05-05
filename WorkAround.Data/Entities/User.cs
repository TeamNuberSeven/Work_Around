using Microsoft.AspNetCore.Identity;

namespace WorkAround.Data.Entities
{
    public class User : IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
