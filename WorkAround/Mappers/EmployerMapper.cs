using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Models;

namespace WorkAround.Mappers
{
    public class EmployerMapper
    {
        public static List<EmployerViewModel> Map(List<Employer> employers, List<User> users)
        {
            var mapper = new List<EmployerViewModel>();
            employers.ForEach(e =>
            {
                var user = users.Where(u => u.Id == e.Id).First();
                mapper.Add(new EmployerViewModel()
                {
                    Id = e.Id,
                    Nickname = user.Nickname,
                    Description = user.Description,
                    Ratings = user.Ratings,
                    Chats = user.Chats,
                    Posts = e.Posts,
                    Proffesion = e.Proffesion,
                    JobConditions = e.JobConditions,
                    Email = user.Email
                });
            });
            return mapper;
        }


        public static EmployerViewModel MapOne(Employer employer, User user)
        {
            return new EmployerViewModel()
            {
                Id = employer.Id,
                Nickname = user.UserName,
                Description = user.Description,
                Ratings = user.Ratings,
                Chats = user.Chats,
                Posts = employer.Posts,
                Proffesion = employer.Proffesion,
                JobConditions = employer.JobConditions,
                Email = user.Email
            };
        }
    }
}
