using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class EmployerViewModel
    {
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public string Id { get; set; }
        public ICollection<Post> Posts { get; set; }
        public string JobConditions { get; set; }
        public WorkArea WorkArea { get; set; }
    }
}
