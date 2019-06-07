using System;
using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Services.Interfaces;
using Microsoft.Extensions.Logging;
using WorkAround.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkAround.Mappers;

namespace WorkAround.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;
        private readonly IEmployerService _employerService;
        private readonly IMessageService _messageService;
        private readonly IWorkAreaService _workAreaService;

        public PostController(
                IPostService postService,
                UserManager<User> userService,
                IEmployerService employerService,
                IMessageService messageService, 
                IWorkAreaService workAreaService)
        {
            _postService = postService;
            _employerService = employerService;
            _messageService = messageService;
            _workAreaService = workAreaService;
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
            var model = new PostCreateViewModel {
                WorkAreaOptions = new SelectList(_workAreaService.GetAll(), nameof(WorkArea.Id), nameof(WorkArea.Title))
            };
            return View(model);
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

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var post = this._postService.GetById(id);
            var employer = _employerService.GetAll().Where(e => e.Id == post.EmployerId).First();
            var user = _userManager.Users.Where(u => u.Id == employer.UserId).First();
            var employerModel = EmployerMapper.MapOne(employer, user);

            var workArea = _workAreaService.GetById(post.WorkAreaId);

            var isEmployee = user.Employee != null;

            var viewModel = new PostDetailViewModel(isEmployee, post, employerModel, workArea.Title);
            return View(viewModel);
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateViewModel model)
        {
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            var post = new Post {
                Id = model.Id,
                Deadline = model.Deadline,
                Description = model.Description,
                Employer = employer,
                PaymentType = model.PaymentType,
                Price = model.Price,
                Title = model.Title,
                WorkAreaId = model.SelectedWorkArea
            };
            this._postService.CreateItem(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Post post = _postService.GetById(id);
            var model = new PostCreateViewModel
            {
                WorkAreaOptions = new SelectList(_workAreaService.GetAll(), nameof(WorkArea.Id), nameof(WorkArea.Title)),
                SelectedWorkArea = post.WorkAreaId,
                Id = post.Id,
                Description = post.Description,
                Price = post.Price,
                Deadline = post.Deadline,
                PaymentType = post.PaymentType,
                Title = post.Title,
                EmployerId = post.EmployerId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PostCreateViewModel model) {
            var employer = _employerService.GetById(model.EmployerId);

            var post = new Post {
                Id = model.Id,
                Deadline = model.Deadline,
                Description = model.Description,
                Employer = employer,
                EmployerId = model.EmployerId,
                PaymentType = model.PaymentType,
                Price = model.Price,
                Title = model.Title,
                WorkAreaId = model.SelectedWorkArea
            };

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