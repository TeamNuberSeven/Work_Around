using System.Collections.Generic;

namespace WorkAround.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
