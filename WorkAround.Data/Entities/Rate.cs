using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class Rate
    {
        public string Id { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
