using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Services.Interfaces;

namespace WorkAround.Controllers
{
    public class WorkAreasController : Controller
    {
        private readonly IWorkAreaService _workAreaService;

        public WorkAreasController(IWorkAreaService workAreaService) {
            _workAreaService = workAreaService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(_workAreaService.GetAll());
        }
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = _workAreaService.GetAll()
                .FirstOrDefault(m => m.Id == id);
            if (workArea == null)
            {
                return NotFound();
            }

            return View(workArea);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title")] WorkArea workArea)
        {
            if (ModelState.IsValid)
            {
                _workAreaService.CreateItem(workArea);
                return RedirectToAction(nameof(Index));
            }
            return View(workArea);
        }
        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = _workAreaService.GetById(id);
            if (workArea == null)
            {
                return NotFound();
            }
            return View(workArea);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title")] WorkArea workArea)
        {
            if (id != workArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _workAreaService.UpdateItem(workArea);
                
                return RedirectToAction(nameof(Index));
            }
            return View(workArea);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = _workAreaService.GetById(id);
            if (workArea == null)
            {
                return NotFound();
            }

            return View(workArea);
        }
        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var workArea = _workAreaService.GetById(id);
            _workAreaService.DeleteById(workArea.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool WorkAreaExists(string id)
        {
            return _workAreaService.GetAll().Any(e => e.Id == id);
        }
    }
}
