using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkAround.Models;
using WorkAround.Services.Interfaces;


namespace WorkAround.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
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

        [HttpPost]
        public IActionResult Create(Post post)
        {
            this._postService.CreateItem(post);
            return RedirectToAction("Index");
        }

    }
}