using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkAround.Models;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Employer = new Employer()
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, model.Role);

                if (result.Succeeded && model.Role == "Employer")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if(result.Succeeded && model.Role == "Employee")
                {
                    return RedirectToAction("FillDetails", "Employee");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(model.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Incorrect login and (or) password");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
