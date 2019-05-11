using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WorkAround.Data.Entities
{
    public class User : IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
