using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class PostCreateViewModel
    {
        [BindProperty]
        public string SelectedWorkArea { get; set; }
        public SelectList WorkAreaOptions { get; set; }

        public string Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Deadline { get; set; }
        public string PaymentType { get; set; }
        public string Title { get; set; }
        public string EmployerId { get; set; }
    }
}
