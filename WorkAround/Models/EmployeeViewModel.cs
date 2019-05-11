using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class EmployeeViewModel
    {
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public string Id { get; set; }
        public ICollection<WorkArea> WorkAreas { get; set; }
        public double ExperienceTime { get; set; }
        public string CVUrl { get; set; }
    }
}
