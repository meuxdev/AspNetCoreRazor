using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRazor.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreRazor.Controllers
{
    public class AssignmentController: Controller
    {
        private readonly SchoolContext _schoolContext;

        public AssignmentController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<IActionResult> Index()
        {
            var assignment = await _schoolContext.Assignments.FirstOrDefaultAsync();
            return View(assignment);
        }

        public IActionResult All()
        {
            var listaAsignaturas = _schoolContext.Assignments.ToList();
            ViewBag.Date = DateTime.Now;
            return View(listaAsignaturas);
        }
    }
}
