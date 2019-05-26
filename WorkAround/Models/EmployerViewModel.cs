using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkAround.Data.Entities;

namespace WorkAround.Models
{
    public class EmployerViewModel
    {
        [BindProperty]
        public string SelectedProffesion { get; set; }
        public SelectList ProffesionOptions { get; set; }

        public string Nickname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public ICollection<Rate> Ratings { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public string Id { get; set; }
        public ICollection<Post> Posts { get; set; }
        public string JobConditions { get; set; }
        public Proffesion Proffesion { get; set; }
    }
}
