using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Services.Interfaces;
using Microsoft.Extensions.Logging;
using WorkAround.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WorkAround.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<Employee> _employeeManager;
        private readonly ILogger _logger;

        public PostController(IPostService postService, ILogger<PostController> logger, UserManager<Employee> employeeService)
        {
            _postService = postService;
            _logger = logger;
            _employeeManager = employeeService;
        }
        public IActionResult Index()
        {
            var posts = this._postService.GetAll();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var post = this._postService.GetById(id);
            var employee = await this._employeeManager.GetUserAsync(HttpContext.User);
            var viewModel = new PostDetailViewModel(post, employee);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var employee = await this._employeeManager.GetUserAsync(HttpContext.User);
            post.Employee = employee;
            this._postService.CreateItem(post);
            return RedirectToAction("Index");
        }

    }
}