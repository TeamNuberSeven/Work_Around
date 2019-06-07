using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class PostDetailViewModel
    {
        public PostDetailViewModel(bool isEmployee, Post post, EmployerViewModel employer, string workAreaTitle) {
            this.IsEmployee = isEmployee;
            this.post = post;
            this.employer = employer;
            this.WorkAreaTitle = workAreaTitle;
        }
        public bool IsEmployee { get; set; }
        public Post post { get; set; }
        public string WorkAreaTitle { get; set; }
        public EmployerViewModel employer { get; set; }
    }
}
