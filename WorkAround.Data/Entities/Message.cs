using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public User User { get; set; }
    }
}
