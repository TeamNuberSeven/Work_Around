using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class PostLike
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
    }
}
