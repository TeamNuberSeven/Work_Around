using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class PostDetailViewModel
    {
        public PostDetailViewModel(Post post, EmployerViewModel employer) {
            this.post = post;
            this.employer = employer;
        }
        public Post post { get; set; }
        public EmployerViewModel employer { get; set; }
    }
}
