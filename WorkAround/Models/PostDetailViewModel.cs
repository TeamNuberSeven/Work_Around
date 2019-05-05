using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class PostDetailViewModel
    {
        public PostDetailViewModel(Post post, Employee employee) {
            this.post = post;
            this.employee = employee;
        }
        public Post post { get; set; }
        public Employee employee { get; set; }
    }
}
