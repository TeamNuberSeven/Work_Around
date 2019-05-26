using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class EmployeeViewModel
    {
        [BindProperty]
        public string[] SelectedProffesions { get; set; }
        public SelectList ProffesionOptions { get; set; }

        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public string Id { get; set; }
        public ICollection<Proffesion> Proffesions { get; set; }
        public double ExperienceTime { get; set; }
        public string CVUrl { get; set; }
        public string Email { get; set; }
    }
}
