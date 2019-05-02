using System;

namespace WorkAround.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Deadline { get; set; }
        public string PaymentType { get; set; }
        public Employee Employee { get; set; }
    }
}
