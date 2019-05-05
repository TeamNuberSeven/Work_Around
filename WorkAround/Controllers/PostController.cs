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
            var posts = this._postService.;
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}