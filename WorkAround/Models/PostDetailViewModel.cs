using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class PostDetailViewModel
    {
        public PostDetailViewModel(bool isEmployee, Post post, EmployerViewModel employer, PostLike like, int likeAmount) {
            this.IsEmployee = isEmployee;
            this.post = post;
            this.employer = employer;
            this.like = like;
            this.likeAmount = likeAmount;
        }
        public bool IsEmployee { get; set; }
        public Post post { get; set; }
        public EmployerViewModel employer { get; set; }
        public PostLike like { get; set; }
        public int likeAmount { get; set; }
    }
}
