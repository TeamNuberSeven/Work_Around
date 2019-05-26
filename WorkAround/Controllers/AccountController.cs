using WorkAround.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkAround.Models;
using System.Linq;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployerService _employerService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmployeeService employeeService,
            IEmployerService employerService
        )
        {
            _employeeService = employeeService;
            _employerService = employerService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _signInManager.SignOutAsync();

                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (loginResult.Succeeded && model.Role == "Employer")
                    {
                        var employer = new Employer()
                        {
                            User = user,
                            UserId = user.Id
                        };
                        _employerService.CreateItem(employer);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (loginResult.Succeeded && model.Role == "Employee")
                    {
                        var employee = new Employee()
                        {
                            User = user,
                            UserId = user.Id
                        };
                        _employeeService.CreateItem(employee);
                        return RedirectToAction("FillDetails", "Employee");
                    }
                    else if(loginResult.Succeeded && model.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        model.Error = loginResult.ToString();
                        return View(model);
                    }
                } else
                {
                    model.Error = result.Errors.ElementAt(0).Description;
                    return View(model);
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

                if (result.Succeeded && !(await _userManager.IsInRoleAsync(user, "Admin")))
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(model.ReturnUrl);
                }
                else if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (result.IsLockedOut)
                {
                    model.Error = "Your account temporary disabled, contact admin";
                    return View(model);
                }
            }
            model.Error = "Incorrect login and (or) password";
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
