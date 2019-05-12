using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;
using WorkAround.Models;

namespace WorkAround.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmployerService _employerService;
        private readonly UserManager<User> _userManager;

        public EmployerController(IEmployerService employerService, UserManager<User> userManager)
        {
            _employerService = employerService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employer employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            EmployerViewModel model = new EmployerViewModel()
            {
                Nickname = user.UserName,
                Description = user.Description,
                Email = user.Email,
                JobConditions = employer.JobConditions
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(EmployerViewModel employer)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employer newEmployer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            newEmployer.JobConditions = employer.JobConditions;
            _employerService.UpdateItem(newEmployer);
            user.Email = employer.Email;
            user.UserName = employer.Nickname;
            user.Description = employer.Description;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
