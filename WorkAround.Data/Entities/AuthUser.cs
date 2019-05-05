using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class AuthUser
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Proffesion> Proffesions { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
