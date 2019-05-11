using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;

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
        public IActionResult MyAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(Employer employer)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employer newEmployer = _employerService.GetAll().Where(e => e.UserId == user.Id).First();
            newEmployer.WorkArea = employer.WorkArea;
            newEmployer.JobConditions = employer.JobConditions;
            newEmployer.Posts = employer.Posts;
            _employerService.UpdateItem(newEmployer);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
