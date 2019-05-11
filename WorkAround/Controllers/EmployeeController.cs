using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeSevice;
        private readonly UserManager<User> _userManager;

        public EmployeeController(IEmployeeService employeeService, UserManager<User> userManager)
        {
            _employeeSevice = employeeService;
            _userManager = userManager;
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
    }
}