using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Data;
using WorkAround.Data.Entities;

namespace WorkAround.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext context;
        public PostController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var posts = this.context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}