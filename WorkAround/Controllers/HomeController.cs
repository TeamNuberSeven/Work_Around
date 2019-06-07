using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Data.Entities;
using WorkAround.Mappers;
using WorkAround.Models;
using WorkAround.Services.Interfaces;
using PagedList;
using WorkAround.Services.DTO;

namespace WorkAround.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<User> _userManager;
        public HomeController(
            IPostService postService,
            IEmployeeService employeeService,
            UserManager<User> userManager
            )
        {
            _postService = postService;
            _employeeService = employeeService;
            _userManager = userManager;
            
        }
        public IActionResult Index(string sortBy, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var posts = this._postService.GetAll();
            var employees = EmployeeMapper.Map(_employeeService.GetAll().ToList(), _userManager.Users.ToList());
            //if (sortBy == "up")
            //{
            //    model.Posts.Sort(new SortPosts());
            //}
            //else if(sortBy == "down")
            //{
            //    model.Posts.Sort(new SortPostsDown());
            //}
            return View(new HomeIndexViewModel
            {
                Posts = posts.ToPagedList(pageNumber,pageSize),
                Employees = employees.ToPagedList(pageNumber,pageSize)
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private class SortPosts : IComparer<Post>
        {
            int IComparer<Post>.Compare(Post a, Post b)
            {
                if (a.Price > b.Price) {
                    return 1;
                }
                else if(a.Price < b.Price)
                {
                    return -1;
                }
                return 0;
            }
        }

        private class SortPostsDown : IComparer<Post>
        {
            int IComparer<Post>.Compare(Post a, Post b)
            {
                if (a.Price < b.Price)
                {
                    return 1;
                }
                else if (a.Price > b.Price)
                {
                    return -1;
                }
                return 0;
            }
        }
    }
}
