using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Data.Entities;
using WorkAround.Models;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeSevice;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public EmployeeController(
                IEmployeeService employeeService,
                UserManager<User> userManager,
                SignInManager<User> signInManager
            )
        {
            _employeeSevice = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult FillDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FillDetails(Employee employee)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employee updatedEmployee = _employeeSevice.GetAll().Where(e => e.UserId == user.Id).First();
            updatedEmployee.CVUrl = employee.CVUrl;
            updatedEmployee.ExperienceTime = employee.ExperienceTime;
            user.Description = employee.User.Description;
            _employeeSevice.UpdateItem(updatedEmployee);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employee employee= _employeeSevice.GetAll().Where(e => e.UserId == user.Id).First();
            EmployeeViewModel model = new EmployeeViewModel()
            {
                Nickname = user.UserName,
                Description = user.Description,
                Email = user.Email,
                ExperienceTime = employee.ExperienceTime,
                CVUrl = employee.CVUrl,
                Id = user.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(EmployeeViewModel employee)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Employee newEmployee = _employeeSevice.GetAll().Where(e => e.UserId == user.Id).First();
            newEmployee.ExperienceTime = employee.ExperienceTime;
            newEmployee.CVUrl = employee.CVUrl;
            _employeeSevice.UpdateItem(newEmployee);
            user.Email = employee.Email;
            user.UserName = employee.Nickname;
            user.Description = employee.Description;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _signInManager.SignOutAsync();
            var employee = _employeeSevice.GetAll().Where(e => e.UserId == user.Id).First();
            _employeeSevice.DeleteById(employee.Id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}