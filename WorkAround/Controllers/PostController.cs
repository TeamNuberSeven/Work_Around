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
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public PostController(IPostService postService, ILogger<PostController> logger, UserManager<User> userService)
        {
            _postService = postService;
            _logger = logger;
            _userManager = userService;
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
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var viewModel = new PostDetailViewModel(post, user.Employee);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            post.Employer = user.Employer;
            this._postService.CreateItem(post);
            return RedirectToAction("Index");
        }

    }
}