using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;
using WorkAround.Models;

namespace WorkAround.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmployerService _employerService;
        private readonly IProffesionService _proffesionService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public EmployerController(
                IEmployerService employerService,
                UserManager<User> userManager,
                SignInManager<User> signInManager,
                IProffesionService proffesionService)
        {
            _employerService = employerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _proffesionService = proffesionService;
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
                JobConditions = employer.JobConditions,
                ProffesionOptions = new SelectList(_proffesionService.GetAll(), nameof(Proffesion.Id), nameof(Proffesion.Title), employer.Proffesion?.Id),
                Id = user.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(EmployerViewModel employer)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employer newEmployer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            newEmployer.JobConditions = employer.JobConditions;
            newEmployer.Proffesion = _proffesionService.GetById(employer.SelectedProffesion);
            _employerService.UpdateItem(newEmployer);
            user.Email = employer.Email;
            user.UserName = employer.Nickname;
            user.Description = employer.Description;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _signInManager.SignOutAsync();
            var employer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            _employerService.DeleteById(employer.Id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
