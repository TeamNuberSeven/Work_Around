using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class HomeIndexViewModel
    {
        public List<Post> Posts { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public string PriceSortPredicate { get; set; }
        public string TitleSearch { get; set; }
    }
}
