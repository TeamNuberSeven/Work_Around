using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAround.Data.Entities;
using WorkAround.Models;

namespace WorkAround.Mappers
{
    public class EmployeeMapper
    {
        public static List<EmployeeViewModel> Map(List<Employee> employees, List<User> users)
        {
            var mapped = new List<EmployeeViewModel>();
            employees.ForEach(e =>
            {
                var user = users.Where(u => u.Id == e.UserId).First();
                mapped.Add(new EmployeeViewModel()
                {
                    Id = e.Id,
                    Description = user.Description,
                    Nickname = user.UserName,
                    CVUrl = e.CVUrl,
                    ExperienceTime = e.ExperienceTime,
                    Ratings = user.Ratings,
                    Chats = user.Chats,
                    Proffesions = e.Proffesions,
                    Email = user.Email
                });
            });
            return mapped;
        }
    }
}
