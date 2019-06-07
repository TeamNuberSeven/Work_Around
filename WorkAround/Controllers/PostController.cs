using System;
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
        private readonly IMessageService _messageService;
        private readonly IPostLikeService _postLikeService;

        public PostController(
                IPostService postService,
                UserManager<User> userService,
                IEmployerService employerService,
                IMessageService messageService, 
                IPostLikeService postLikeService)
        {
            _postService = postService;
            _employerService = employerService;
            _messageService = messageService;
            _postLikeService = postLikeService;
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
        public IActionResult AddComment(string id)
        {
            var employer = _employerService.GetById(id);
            var commentModel = new CommentViewModel{EmployerId = employer.Id};
            return View(commentModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel commentModel) {
            
            var comment = new Message {
                EmployerId = commentModel.EmployerId,
                Id = commentModel.Id,
                Sent = DateTime.Now,
                Text = commentModel.Text,
                Title = commentModel.Title,
                User = await this._userManager.GetUserAsync(HttpContext.User)
            };
            
            _messageService.CreateItem(comment);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Like(PostLike like) {
            PostLike postLike = null;
            try {
                postLike = _postLikeService.GetAll().First(l => l.UserId == like.UserId);
            }
            catch (Exception) {
            }
            if (postLike == null) {
                _postLikeService.CreateItem(like);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DisLike(PostLike like) {
            PostLike postLike = null;

            try {
                postLike = _postLikeService.GetById(like.Id);
            }
            catch (Exception) {
            }
            if (postLike != null) {
                _postLikeService.DeleteById(like.Id);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var post = this._postService.GetById(id);
            var employer = _employerService.GetAll().Where(e => e.Id == post.EmployerId).First();
            var user = _userManager.Users.Where(u => u.Id == employer.UserId).First();
            var employerModel = EmployerMapper.MapOne(employer, user);
            
            var isEmployee = user.Employee != null;

            var likes = _postLikeService.GetAll().Where(l => l.PostId == post.Id).ToList();

            var currUser = await _userManager.GetUserAsync(HttpContext.User);
            PostLike like;
            try {
                like = likes.First(l => l.UserId == currUser.Id);
            }
            catch (Exception) {
                
                like = new PostLike
                {
                    UserId = currUser.Id,
                    PostId = post.Id
                };
            }

            var viewModel = new PostDetailViewModel(isEmployee, post, employerModel, like, likes.Count);
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