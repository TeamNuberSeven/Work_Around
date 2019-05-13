using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Services.Interfaces;
using Microsoft.Extensions.Logging;
using WorkAround.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WorkAround.Mappers;

namespace WorkAround.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;
        private readonly IEmployerService _employerService;

        public PostController(
                IPostService postService,
                UserManager<User> userService,
                IEmployerService employerService
            )
        {
            _postService = postService;
            _employerService = employerService;
            _userManager = userService;
        }
        public async Task<IActionResult> Index()
        {
            var posts = this._postService.GetAll();
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            var myPosts = posts.Where(p => p.EmployerId == employer.Id).ToList();
            return View(myPosts);
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
            var employer = _employerService.GetAll().Where(e => e.Id == post.EmployerId).First();
            var user = _userManager.Users.Where(u => u.Id == employer.UserId).First();
            var employerModel = EmployerMapper.MapOne(employer, user);
            var viewModel = new PostDetailViewModel(post, employerModel);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            post.Employer = employer;
            this._postService.CreateItem(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Post post = _postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _postService.UpdateItem(post);
            return RedirectToAction("Index", "Post");
        }

        public IActionResult Delete(string id)
        {
            _postService.DeleteById(id);
            return RedirectToAction("Index", "Post");
        }
    }
}