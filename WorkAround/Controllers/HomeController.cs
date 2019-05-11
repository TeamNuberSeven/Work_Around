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
        public IActionResult Index()
        {
            var posts = this._postService.GetAll();
            var employees = EmployeeMapper.Map(_employeeService.GetAll().ToList(), _userManager.Users.ToList());
            return View(new HomeIndexViewModel(posts.ToList(), employees));
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
    }
}
