using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Services.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
    }
}
