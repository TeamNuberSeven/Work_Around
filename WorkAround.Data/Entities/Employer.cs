using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class Employer
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Post> Posts { get; set; }
        public string JobConditions { get; set; }
        public Proffesion Proffesion { get; set; }
        
    }
}
