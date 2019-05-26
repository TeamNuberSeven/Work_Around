using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WorkAround.Data.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public ICollection<Proffesion> Proffesions { get; set; }
        public double ExperienceTime { get; set; }
        public string CVUrl { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
