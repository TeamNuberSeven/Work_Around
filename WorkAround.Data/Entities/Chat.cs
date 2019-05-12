using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class Chat
    {
        public string Id { get; set; }
        public ICollection<Message> Messages { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
