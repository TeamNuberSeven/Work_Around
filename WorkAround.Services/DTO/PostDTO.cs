using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Services.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Deadline { get; set; }
        public string PaymentType { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
