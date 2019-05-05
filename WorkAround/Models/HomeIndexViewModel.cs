using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(List<Post> posts, List<Employee> employees)
        {
            this.Posts = posts;
            this.Employees = employees;
        }
        public List<Post> Posts { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
