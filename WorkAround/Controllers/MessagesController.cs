using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class MessagesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;
        private readonly IEmployerService _employerService;

        public MessagesController(UserManager<User> userManager,
                                  IMessageService messageService, 
                                  IEmployerService employerService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _employerService = employerService;
        }
        
        public async Task<IActionResult> Index()
        {
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            var messages = _messageService.GetAll();
            var myMessages = messages.Where(m => m.EmployerId == employer.Id).ToList();
            return View(myMessages);
        }
    }
}
