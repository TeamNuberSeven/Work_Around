using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Data.Entities
{
    public class WorkArea
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ICollection<Proffesion> Proffesions { get; set; }
    }
}
