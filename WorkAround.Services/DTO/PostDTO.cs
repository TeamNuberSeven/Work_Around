using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Services.DTO
{
    public class PostDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Deadline { get; set; }
        public string PaymentType { get; set; }
        public Employer Employer { get; set; }
        public string Title { get; set; }
        public string EmployerId { get; set; }
    }
}
