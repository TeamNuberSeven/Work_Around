using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Data.Entities;
using WorkAround.Models;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProffesionService _proffesionService;

        public AdminController(UserManager<User> userManager, IProffesionService proffesionService)
        {
            _userManager = userManager;
            _proffesionService = proffesionService;
        }

        public IActionResult Index()
        {
            var allUsers = _userManager.Users;
            return View(allUsers);
        }

        public async Task<IActionResult> LockUser(string id)
        {
            var exists = _userManager.Users.Any(i => i.Id == id);

            if (exists)
            {
                var user = _userManager.Users.First(i => i.Id == id);
                await _userManager.SetLockoutEnabledAsync(user, true);
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(7));

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnlockUser(string id)
        {
            var exists = _userManager.Users.Any(i => i.Id == id);

            if (exists)
            {
                var user = _userManager.Users.First(i => i.Id == id);
                await _userManager.SetLockoutEnabledAsync(user, false);

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddProffesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProffesion(Proffesion proffesion)
        {
            _proffesionService.CreateItem(proffesion);
            return RedirectToAction("Index", "Home");
        }
        
    }
}